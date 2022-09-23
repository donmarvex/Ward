using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalKiddiesWard.Data.Models
{
    public class User : IdentityUser<int>
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required (ErrorMessage = "Please enter Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(15)]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

    }
}
