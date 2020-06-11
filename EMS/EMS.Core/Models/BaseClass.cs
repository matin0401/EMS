using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models
{
    public class BaseClass
    {
        public string Id { get; set; }

        public BaseClass()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
