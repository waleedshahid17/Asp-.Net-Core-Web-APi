using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Company
    {
        [Column("Company ID")]
        public Guid id { get; set; }

        [Required(ErrorMessage="Company name is a required field")]
        [MaxLength(60,ErrorMessage ="Maximum Limit for the company name is 60 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "Company address is a required field")]
        [MaxLength(60,ErrorMessage = "Maximum Limit for the company address is 60 characters")]
        public string address { get; set; }

        public string country { get; set; }

        public ICollection<Employee> Employees { get; set; } 

    }
}
