using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace TechSolutions.Model
{
    public class MedicalRecord
    {
        [Key]
        public int RecordId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string VisitDetails { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
