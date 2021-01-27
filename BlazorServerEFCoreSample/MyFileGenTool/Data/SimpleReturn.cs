using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data
{
 
    [Keyless]
    public class SimpleReturn
    {
        public string Info { get; set; }
    }
}
