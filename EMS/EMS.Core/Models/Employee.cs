using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models
{
    public class Employee : BaseClass
    {
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Required]
        public string Email { get; set; }

        public string MobileNo { get; set; }

        [Required]
        public string Department { get; set; }
        public string Image { get; set; }
        [Required]
        public string City { get; set; }

    }
}
