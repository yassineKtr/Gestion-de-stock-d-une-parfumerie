using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_stock_d_une_parfumerie.Models
{
    public class Perfume
    {
        private int _id;
        private String _name;
        private decimal _price;

        public int id { get { return _id; } set { _id = value; } }
        public String name { get { return _name; } set { _name = value; } }
        public decimal price { get { return _price; } set { _price = value; } }

        



    }
}
