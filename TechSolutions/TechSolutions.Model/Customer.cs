using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechSolutions.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } 
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public virtual ICollection<CustomerAddress> Addresses { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }

    }
}
