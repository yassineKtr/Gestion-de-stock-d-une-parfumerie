using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    internal class Perfume
    {
        public Guid id { get; set; }
        public String name { get; set; }
        public String brand { get; set; }
        public double promo { get; set; } = 0;
        public double price { get; set; }
    }
}
