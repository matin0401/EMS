using EMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.VIewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }

        public IEnumerable<Department> Department { get; set; }
    }
}
