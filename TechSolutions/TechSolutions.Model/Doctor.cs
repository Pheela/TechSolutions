using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TechSolutions.Model;

namespace TechSolutions.Model
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string Specialization { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}

