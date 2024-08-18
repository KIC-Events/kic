﻿// <auto-generated />
using System;
using KiCData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KiCData.Migrations
{
    [DbContext(typeof(KiCdbContext))]
    [Migration("20240805162539_8-5.1")]
    partial class _851
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("KiCData.Models.Attendee", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool>("BackgroundChecked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("BadgeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ConfirmationNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("RoomPreference")
                        .HasColumnType("longtext");

                    b.Property<bool>("RoomWaitListed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.Property<bool>("TicketWaitListed")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("TicketId");

                    b.ToTable("Attendee");

                    b.HasData(
                        new
                        {
                            Id = 2468,
                            BackgroundChecked = true,
                            BadgeName = "RandomNessy",
                            ConfirmationNumber = 0,
                            IsPaid = true,
                            MemberId = 7725,
                            RoomPreference = "Special",
                            RoomWaitListed = false,
                            TicketId = 1234,
                            TicketWaitListed = false
                        });
                });

            modelBuilder.Entity("KiCData.Models.ClubMember", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ClubMember");
                });

            modelBuilder.Entity("KiCData.Models.Event", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Topic")
                        .HasColumnType("longtext");

                    b.Property<int?>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Event");

                    b.HasData(
                        new
                        {
                            Id = 1111,
                            Description = "This is a test event.",
                            EndDate = new DateOnly(2021, 1, 2),
                            Name = "Test Event",
                            StartDate = new DateOnly(2021, 1, 1),
                            VenueId = 12345
                        });
                });

            modelBuilder.Entity("KiCData.Models.EventVendor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("ConfirmationNumber")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("VendorId");

                    b.ToTable("EventVendor");

                    b.HasData(
                        new
                        {
                            Id = 3333,
                            ConfirmationNumber = 0,
                            EventId = 1111,
                            IsPaid = false,
                            VendorId = 1128
                        });
                });

            modelBuilder.Entity("KiCData.Models.EventVolunteer", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("longtext");

                    b.Property<int?>("ShiftNumber")
                        .HasColumnType("int");

                    b.Property<int?>("VolunteerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("VolunteerId");

                    b.ToTable("EventVolunteer");

                    b.HasData(
                        new
                        {
                            Id = 3579,
                            EventId = 1111,
                            VolunteerId = 1234
                        });
                });

            modelBuilder.Entity("KiCData.Models.Member", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("longtext");

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FetName")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsPresenter")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsStaff")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsVendor")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsVolunteer")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<int?>("PublicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            Id = 7725,
                            AdditionalInfo = "This is a test user.",
                            ClubId = 12345,
                            DateOfBirth = new DateOnly(1980, 1, 1),
                            Email = "John.Doe@example.com",
                            FetName = "JohnDoe",
                            FirstName = "John",
                            IsPresenter = false,
                            IsStaff = false,
                            IsVendor = false,
                            IsVolunteer = true,
                            LastName = "Doe",
                            PhoneNumber = "555-555-5555",
                            PublicId = 54321
                        });
                });

            modelBuilder.Entity("KiCData.Models.Presentation", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("ImgPath")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PresenterId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PresenterId");

                    b.ToTable("Presentation");

                    b.HasData(
                        new
                        {
                            Id = 2222,
                            Description = "This is a test presentation.",
                            EventId = 1111,
                            ImgPath = "/wwwroot/Presentations/image01.jpg",
                            Name = "Test Presentation",
                            PresenterId = 1234
                        });
                });

            modelBuilder.Entity("KiCData.Models.Presenter", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("longtext");

                    b.Property<string>("Details")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Fee")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ImgPath")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("LastAttended")
                        .HasColumnType("date");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("PublicName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Requests")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Presenter");

                    b.HasData(
                        new
                        {
                            Id = 1234,
                            Bio = "This is a test presenter.",
                            Details = "Test Details",
                            Fee = 100.00m,
                            LastAttended = new DateOnly(2021, 1, 1),
                            MemberId = 7725,
                            PublicName = "Test Presenter",
                            Requests = "Test Requests"
                        });
                });

            modelBuilder.Entity("KiCData.Models.Staff", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("MemberId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("KiCData.Models.Ticket", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateOnly?>("DatePurchased")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsComped")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Ticket");

                    b.HasData(
                        new
                        {
                            Id = 1234,
                            DatePurchased = new DateOnly(2021, 1, 1),
                            EndDate = new DateOnly(2021, 1, 2),
                            EventId = 1111,
                            IsComped = false,
                            Price = 10.00m,
                            StartDate = new DateOnly(2021, 1, 1),
                            Type = "Test Ticket"
                        },
                        new
                        {
                            Id = 12354,
                            DatePurchased = new DateOnly(2021, 1, 1),
                            EndDate = new DateOnly(2021, 1, 2),
                            EventId = 1111,
                            IsComped = false,
                            Price = 10.00m,
                            StartDate = new DateOnly(2021, 1, 1),
                            Type = "Test Ticket"
                        });
                });

            modelBuilder.Entity("KiCData.Models.TicketComp", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("AuthorizingUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CompReason")
                        .HasColumnType("longtext");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketComp");
                });

            modelBuilder.Entity("KiCData.Models.User", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("KiCData.Models.Vendor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImgPath")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("LastAttended")
                        .HasColumnType("date");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("MerchType")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("PriceAvg")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("PriceMax")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("PriceMin")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("PublicName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Vendor");

                    b.HasData(
                        new
                        {
                            Id = 1128,
                            Bio = "This is a test vendor.",
                            ImgPath = "/wwwroot/images/Vendors/image01.jpg",
                            LastAttended = new DateOnly(2021, 1, 1),
                            MemberId = 7725,
                            MerchType = "Test Merch",
                            PriceAvg = 5.00m,
                            PriceMax = 10.00m,
                            PriceMin = 1.00m,
                            PublicName = "Test Vendor"
                        });
                });

            modelBuilder.Entity("KiCData.Models.Venue", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float?>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Venue");

                    b.HasData(
                        new
                        {
                            Id = 12345,
                            Address = "123 Test St.",
                            Capacity = 100,
                            City = "Test City",
                            Name = "Test Venue",
                            State = "TS"
                        });
                });

            modelBuilder.Entity("KiCData.Models.Volunteer", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Details")
                        .HasColumnType("longtext");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Positions")
                        .HasColumnType("longtext");

                    b.Property<string>("Shifts")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Volunteer");

                    b.HasData(
                        new
                        {
                            Id = 1234,
                            Details = "Test Details",
                            MemberId = 7725,
                            Positions = "[\"Test Position\"]"
                        });
                });

            modelBuilder.Entity("KiCData.Models.WaitList", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("AttendeeId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AttendeeId");

                    b.ToTable("WaitList");
                });

            modelBuilder.Entity("KiCData.Models.Attendee", b =>
                {
                    b.HasOne("KiCData.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.HasOne("KiCData.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");

                    b.Navigation("Member");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("KiCData.Models.Event", b =>
                {
                    b.HasOne("KiCData.Models.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("KiCData.Models.EventVendor", b =>
                {
                    b.HasOne("KiCData.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KiCData.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("KiCData.Models.EventVolunteer", b =>
                {
                    b.HasOne("KiCData.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("KiCData.Models.Volunteer", "Volunteer")
                        .WithMany()
                        .HasForeignKey("VolunteerId");

                    b.Navigation("Event");

                    b.Navigation("Volunteer");
                });

            modelBuilder.Entity("KiCData.Models.Presentation", b =>
                {
                    b.HasOne("KiCData.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KiCData.Models.Presenter", "Presenter")
                        .WithMany()
                        .HasForeignKey("PresenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Presenter");
                });

            modelBuilder.Entity("KiCData.Models.Presenter", b =>
                {
                    b.HasOne("KiCData.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("KiCData.Models.Staff", b =>
                {
                    b.HasOne("KiCData.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("KiCData.Models.Ticket", b =>
                {
                    b.HasOne("KiCData.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("KiCData.Models.TicketComp", b =>
                {
                    b.HasOne("KiCData.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("KiCData.Models.User", b =>
                {
                    b.HasOne("KiCData.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("KiCData.Models.Vendor", b =>
                {
                    b.HasOne("KiCData.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("KiCData.Models.Volunteer", b =>
                {
                    b.HasOne("KiCData.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("KiCData.Models.WaitList", b =>
                {
                    b.HasOne("KiCData.Models.Attendee", "Attendee")
                        .WithMany()
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");
                });
#pragma warning restore 612, 618
        }
    }
}
