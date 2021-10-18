using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CompanyForManipulationDto
    {
        [Required(ErrorMessage = "Company name is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum Limit for the company name is 60 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "Company address is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum Limit for the company address is 60 characters")]
        public string address { get; set; }
        public string country { get; set; }
        public IEnumerable<EmployeeForCreationDto> Employees { get; set; }

    }
}
