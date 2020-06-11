using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models
{
    public class Admin : BaseClass
    {
        [Required]
        [Display(Name = "Admin Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(7, 14)]
        [Required]
        public string Password { get; set; }
    }
}
