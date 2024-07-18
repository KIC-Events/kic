﻿// <auto-generated />
using System;
using KiCData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KiCData.Migrations
{
    [DbContext(typeof(KiCdbContext))]
    partial class KiCdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

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

                    b.ToTable("ClubMembers", (string)null);
                });

            modelBuilder.Entity("KiCData.Models.Event", b =>
                {
                    b.Property<Guid?>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Topic")
                        .HasColumnType("longtext");

                    b.Property<int?>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("VenueId");

                    b.ToTable("Events", (string)null);
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

                    b.Property<Guid?>("EventId1")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.Property<Guid?>("VendorId1")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EventId1");

                    b.HasIndex("VendorId1");

                    b.ToTable("EventVendors", (string)null);
                });

            modelBuilder.Entity("KiCData.Models.EventVolunteer", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<Guid?>("EventId1")
                        .HasColumnType("char(36)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ShiftNumber")
                        .HasColumnType("int");

                    b.Property<int>("VolunteerId")
                        .HasColumnType("int");

                    b.Property<Guid?>("VolunteerId1")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EventId1");

                    b.HasIndex("VolunteerId1");

                    b.ToTable("EventVolunteers", (string)null);
                });

            modelBuilder.Entity("KiCData.Models.Member", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

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

                    b.ToTable("Members", (string)null);

                    b.UseTptMappingStrategy();
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

                    b.Property<Guid>("EventId1")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PresenterId")
                        .HasColumnType("int");

                    b.Property<Guid?>("PresenterId1")
                        .HasColumnType("char(36)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventId1");

                    b.HasIndex("PresenterId1");

                    b.ToTable("Presentations", (string)null);
                });

            modelBuilder.Entity("KiCData.Models.Staff", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<Guid?>("MemberId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Staff", (string)null);
                });

            modelBuilder.Entity("KiCData.Models.Ticket", b =>
                {
                    b.Property<int?>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("TicketId"));

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("char(36)");

                    b.Property<bool?>("IsComped")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("TicketId");

                    b.HasIndex("EventId");

                    b.ToTable("Ticket", (string)null);
                });

            modelBuilder.Entity("KiCData.Models.TicketComp", b =>
                {
                    b.Property<int?>("CompId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("CompId"));

                    b.Property<string>("AuthorizingUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CompReason")
                        .HasColumnType("longtext");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("CompId");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketComp", (string)null);
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Venue", (string)null);
                });

            modelBuilder.Entity("KiCData.Models.Attendee", b =>
                {
                    b.HasBaseType("KiCData.Models.Member");

                    b.Property<bool>("BackgroundChecked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("BadgeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ConfirmationNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RoomPreference")
                        .HasColumnType("longtext");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<bool>("WaitListed")
                        .HasColumnType("tinyint(1)");

                    b.HasIndex("TicketId");

                    b.ToTable("Attendees", (string)null);
                });

            modelBuilder.Entity("KiCData.Models.Presenter", b =>
                {
                    b.HasBaseType("KiCData.Models.Member");

                    b.Property<string>("Bio")
                        .HasColumnType("longtext");

                    b.Property<string>("Details")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Fee")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateOnly?>("LastAttended")
                        .HasColumnType("date");

                    b.Property<string>("PublicName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Requests")
                        .HasColumnType("longtext");

                    b.ToTable("Presenters", (string)null);
                });

            modelBuilder.Entity("KiCData.Models.User", b =>
                {
                    b.HasBaseType("KiCData.Models.Member");

                    b.Property<Guid?>("MemberId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasIndex("MemberId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("KiCData.Models.Vendor", b =>
                {
                    b.HasBaseType("KiCData.Models.Member");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("LastAttended")
                        .HasColumnType("date");

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

                    b.ToTable("Vendors", (string)null);
                });

            modelBuilder.Entity("KiCData.Models.Volunteer", b =>
                {
                    b.HasBaseType("KiCData.Models.Member");

                    b.Property<string>("Details")
                        .HasColumnType("longtext");

                    b.Property<string>("Positions")
                        .HasColumnType("longtext");

                    b.ToTable("Volunteers", (string)null);
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
                        .HasForeignKey("EventId1");

                    b.HasOne("KiCData.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId1");

                    b.Navigation("Event");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("KiCData.Models.EventVolunteer", b =>
                {
                    b.HasOne("KiCData.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId1");

                    b.HasOne("KiCData.Models.Volunteer", "Volunteer")
                        .WithMany()
                        .HasForeignKey("VolunteerId1");

                    b.Navigation("Event");

                    b.Navigation("Volunteer");
                });

            modelBuilder.Entity("KiCData.Models.Presentation", b =>
                {
                    b.HasOne("KiCData.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KiCData.Models.Presenter", "Presenter")
                        .WithMany()
                        .HasForeignKey("PresenterId1");

                    b.Navigation("Event");

                    b.Navigation("Presenter");
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

            modelBuilder.Entity("KiCData.Models.Attendee", b =>
                {
                    b.HasOne("KiCData.Models.Member", null)
                        .WithOne()
                        .HasForeignKey("KiCData.Models.Attendee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KiCData.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("KiCData.Models.Presenter", b =>
                {
                    b.HasOne("KiCData.Models.Member", null)
                        .WithOne()
                        .HasForeignKey("KiCData.Models.Presenter", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KiCData.Models.User", b =>
                {
                    b.HasOne("KiCData.Models.Member", null)
                        .WithOne()
                        .HasForeignKey("KiCData.Models.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KiCData.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("KiCData.Models.Vendor", b =>
                {
                    b.HasOne("KiCData.Models.Member", null)
                        .WithOne()
                        .HasForeignKey("KiCData.Models.Vendor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KiCData.Models.Volunteer", b =>
                {
                    b.HasOne("KiCData.Models.Member", null)
                        .WithOne()
                        .HasForeignKey("KiCData.Models.Volunteer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
