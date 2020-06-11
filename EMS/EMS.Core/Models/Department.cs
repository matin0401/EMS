using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models
{
    public class Department : BaseClass
    {
        [Display(Name = "Department Name")]
        [Required]
        public string Name { get; set; }
    }
}
