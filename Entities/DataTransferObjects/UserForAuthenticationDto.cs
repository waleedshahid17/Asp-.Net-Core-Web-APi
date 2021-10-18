using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage="Username Required")]
        public string Username { get; set; }
        [Required(ErrorMessage="Password Required")]
        public string password { get; set; }
    }
}
