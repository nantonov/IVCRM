﻿namespace IVCRM.DAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
