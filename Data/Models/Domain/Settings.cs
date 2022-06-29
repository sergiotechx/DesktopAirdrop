using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Domain
{
    public class Settings
    {
        public string Address { get; set; }
        public string PrivateKey { get; set; }
        public string Contract { get; set; }
       public int ChainId { get; set; }
        public string ConnectionString { get; set; }

        public Settings()
        {
            Address = String.Empty;
            PrivateKey = String.Empty;
            Contract = String.Empty;
            ConnectionString = String.Empty;
        }
    }
}
