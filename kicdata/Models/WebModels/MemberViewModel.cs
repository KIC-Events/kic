﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiCData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KiCData.Models.WebModels
{
    public class MemberViewModel
    {

        [Required(ErrorMessage = "Please enter your legal first name.")]
        [Display(Name = "Legal First Name (as it appears on your ID)")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your legal last name.")]
        [Display(Name = "Legal Last Name (as it appears on your ID)")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your birthday")]
        [Display(Name = "Date of Birth")]
        public DateOnly? DateOfBirth { get; set; }

        [Display(Name = "Fetlife Profile Name (Optional)")]
        public string? FetName { get; set; }

        [Display(Name = @"If you are a member of Club425, where our monthly parties are held, please enter your member number here. (This number was provided on registration.)")]
        public int? ClubId { get; set; }

        [Display(Name = @"Phone Number (Optional)")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Additional Information")]
        public string? AdditionalInfo { get; set; }

        [Required]
        [Display(Name = "The sex listed on your ID card. This is used for background check purposes only. KIC Events is an inclusive organization that welcomes all participants without regards to gender or sex.")]
        public string? SexOnID { get; set; }
    }

    public class RegistrationViewModel : AttendeeViewModel
    {
        [Required]
        [Display(Name = "Ticket Level")]
        public string? TicketType { get; set; }

        public List<SelectListItem>? TicketTypes { get; set; }

        [Display(Name = "Room Type (This does not guarentee the selected room type will be available, but indicates preference.")]
        public string? RoomType { get; set; }

        public List<SelectListItem> RoomTypes { get; set; }

        [Required]
        [Display(Name = "Check this if you would like to reserve a room at the host hotel.")]
        public bool IsStaying = false;

        [Required]
        [Display(Name = "Check here if you are interested in volunteering at the event.")]
        public bool WillVolunteer = false;

        [Required]
        [Display(Name = "Re-enter your email address to confirm.")]
        public string EmailConf { get; set; }

        public bool CreateMore = false;

        public string? DiscountCode { get; set; }

        public TicketComp? TicketComp { get; set; }

        [Required]
        [Display(Name = "City of Residence")]
        public string? City { get; set; }

        [Required]
        [Display(Name = "State of Residence")]
        public string? State { get; set; }

        public bool WaitList { get; set; } = false;
    }

    public class VolunteerPositionSelection
    {
        public string Name { get; set; }
        public bool Value { get; set; } = false;

        public VolunteerPositionSelection(string name, bool value)
        {
            Name = name;
            Value = value;
        }

        public VolunteerPositionSelection(string name)
        {
            Name = name;
        }
    }

    public class PeopleViewModel
    {
        public List<KiCData.Models.Member> members { get; set; }
        public List<Volunteer> volunteers { get; set; }
        public List<PendingVolunteer> pendingVolunteers { get; set; }
        public List<Vendor> vendors { get; set; }
        public List<Staff> staff { get; set; }
        public List<Presenter> presenters { get; set; }

        public PeopleViewModel(List<KiCData.Models.Member> members, List<Volunteer> volunteers, List<PendingVolunteer> pendingVolunteers, List<Vendor> vendors, List<Staff> staff, List<Presenter> presenters)
        {
            this.members = members;
            this.volunteers = volunteers;
            this.pendingVolunteers = pendingVolunteers;
            this.vendors = vendors;
            this.staff = staff;
            this.presenters = presenters;
        }
    }
}
