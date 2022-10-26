﻿using System.ComponentModel.DataAnnotations;

namespace IVCRM.API.Requests
{
    public class UpdateCustomerRequest
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
    }
}
