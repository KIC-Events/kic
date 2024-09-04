﻿using KiCData.Models.WebModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Square;
using Square.Authentication;
using Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KiCData.Services
{
    public class PaymentService : IPaymentService
    {
        private SquareClient _client;
        private IKiCLogger _logger;

        public PaymentService(IConfigurationRoot configuration, IKiCLogger logger)
        {
            Square.Environment env = Square.Environment.Production;

            if (configuration["Square:Environment"] == "Sandbox")
            {
                env = Square.Environment.Sandbox;
            }

            _client = new SquareClient.Builder().BearerAuthCredentials
                (
                    new BearerAuthModel.Builder(configuration["Square:Token"])
                    .Build()
                )
                .Environment(env)
                .Build();
            _logger = logger;
        }

        public int CheckInventory(string objectSearchTerm, string variationSearchTerm)
        {
            try
            {
                int response = checkInventory(objectSearchTerm, variationSearchTerm);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        private int checkInventory(string objectSearchTerm, string variationSearchTerm)
        {
            ListCatalogResponse catResponse = _client.CatalogApi.ListCatalog();
            CatalogObject obj = catResponse.Objects
                .Where(o => o.ItemData.Name.Contains(objectSearchTerm))
                .FirstOrDefault();

            if (obj == null)
            {
                throw new Exception("Object not found.");
            }

            string varId = obj.ItemData.Variations
                .Where(v => v.ItemVariationData.Name.Contains(variationSearchTerm))
                .FirstOrDefault()
                .Id;

            RetrieveInventoryCountResponse countResponse = _client.InventoryApi.RetrieveInventoryCount(varId);

            if (countResponse.Counts == null)
            {
                throw new Exception("No count for " + variationSearchTerm + " found.");
            }

            if(countResponse.Counts.Count > 1)
            {
                throw new Exception("Found multiple counts for " + variationSearchTerm + ".");
            }

            InventoryCount count = countResponse.Counts.FirstOrDefault();

            int response = int.Parse(count.Quantity);

            return response;
        }

        public string CreatePaymentLink(List<RegistrationViewModel> regList)
        {
            string paymentLink = createPaymentLink(regList);

            return paymentLink;
        }

        private string createPaymentLink(List<RegistrationViewModel> regList)
        {
            List<OrderLineItem> orderLineItems = new List<OrderLineItem>();
            List<OrderLineItemDiscount> orderDiscounts = new List<OrderLineItemDiscount>();

            var locations = _client.LocationsApi.ListLocations();
            string locationID = locations.Locations.FirstOrDefault().Id;

            foreach (RegistrationViewModel reg in regList)
            {
                ListCatalogResponse catalog = _client.CatalogApi.ListCatalog();
                CatalogObject catObj = catalog.Objects
                    .Where(o => o.ItemData.Name == "CURE Event Ticket")
                    .FirstOrDefault();
                string id = catObj.Id;
                CatalogObject variation = catObj.ItemData.Variations.Where(v => v.ItemVariationData.Name == reg.TicketType).FirstOrDefault();
                string varId = variation.Id;

                var appliedDiscounts = new List<OrderLineItemAppliedDiscount>();

                if(reg.DiscountCode != null)
                {
                    if (reg.TicketComp.CompPct == 100)
                    {
                        break;
                    }
                    OrderLineItemAppliedDiscount orderLineItemAppliedDiscount = new OrderLineItemAppliedDiscount.Builder(discountUid: reg.DiscountCode)
                        .Build();
                    appliedDiscounts.Add(orderLineItemAppliedDiscount);

                    long discountAmt = ((long)reg.TicketComp.CompAmount * 10);

                    Money discountAmount = new Money.Builder()
                        .Amount(discountAmt)
                        .Currency("USD")
                        .Build();

                    OrderLineItemDiscount orderLineItemDiscount = new OrderLineItemDiscount.Builder()
                        .Uid(reg.DiscountCode)
                        .Name(reg.TicketComp.CompReason)
                        .AmountMoney(discountAmount)
                        .Scope("LINE_ITEM")
                        .Build();

                    orderDiscounts.Add(orderLineItemDiscount);
                }

                OrderLineItem orderLineItem = new OrderLineItem.Builder(quantity: "1")
                    .CatalogObjectId(varId)
                    .AppliedDiscounts(appliedDiscounts)
                    .Build();

                orderLineItems.Add(orderLineItem);
            }

            string paymentLink = "";

            if(orderLineItems.Count == 0)
            {
                paymentLink = "https://cure.kicevents.com/Success";
                return paymentLink;
            }

            OrderServiceCharge orderServiceCharge = new OrderServiceCharge.Builder()
                .Name("Handling Fee")
                .Percentage("3")
                .CalculationPhase("SUBTOTAL_PHASE")
                .Build();

            List<OrderServiceCharge> serviceCharges = new List<OrderServiceCharge>();
            serviceCharges.Add(orderServiceCharge);

            OrderPricingOptions pricingOptions = new OrderPricingOptions.Builder()
                .AutoApplyTaxes(true)
                .Build();

            Order order = new Order.Builder(locationId: locationID)
                .LineItems(orderLineItems)
                .PricingOptions(pricingOptions)
                .ServiceCharges(serviceCharges)
                .Build();

            //CreateOrderRequest orderRequest = new CreateOrderRequest.Builder()
            //    .IdempotencyKey(Guid.NewGuid().ToString())
            //    .Order(order)
            //    .Build();
            //
            //CreateOrderResponse orderResponse = _client.OrdersApi.CreateOrder(orderRequest);

            CheckoutOptions options = new CheckoutOptions.Builder()
                .RedirectUrl("https://cure.kicevents.com/")
                .Build();

            CreatePaymentLinkRequest paymentRequest = new CreatePaymentLinkRequest.Builder()
                .IdempotencyKey(Guid.NewGuid().ToString())
                .Order(order)
                .CheckoutOptions(options)
                .Build();

            try
            {
                CreatePaymentLinkResponse response = _client.CheckoutApi.CreatePaymentLink(paymentRequest);

                paymentLink = response.PaymentLink.Url;
            }
            catch(Square.Exceptions.ApiException ex)
            {
                _logger.Log(ex);
                paymentLink = "https://cure.kicevents.com/Error";
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                paymentLink = "https://cure.kicevents.com/Error";
            }

            return paymentLink;
        }
    }
}
