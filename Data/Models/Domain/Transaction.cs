using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Domain
{
    public class Transaction
    {
        public string Address { get; set; }
        public decimal Qty { get; set; }
        public string HashId { get; set; }
    }
  
}
