﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppointment.Models
{
    public class User
    {
        [Required]
        [Display(Name ="PPS No.")]
        [RegularExpression("[0-9]{6,7}[A-Z]{1}")]
        public string PPSNo { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Not a valid email address")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Choose Your Date")]
        public DateTime Date { get; set; }
    }
}