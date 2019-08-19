using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evolent.Models.ContactModel
{
    public class Contact
    {
        public int Id { get; set; }
     
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        private Status _status;
        public string Status
        {
            get
            {
                return Enum.GetName(typeof(Status), _status);
            }
            set
            {
                _status = (Status)Enum.Parse(typeof(Status), value.ToString());
            }
        }
    }

    public enum Status
    {
        //[Display(Name = "Active")]
        Active,
        //[Display(Name = "Inactive")]
        Inactive
    }
}
