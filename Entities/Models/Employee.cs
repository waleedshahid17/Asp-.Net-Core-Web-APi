﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Employee
    {
        [Column("Employee ID")]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Employee name is a required field")]
        [MaxLength(30,ErrorMessage = "Maximum Limit for the employee name is 30 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "Age is a required field.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string Position { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
