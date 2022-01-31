using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockCDN.Models
{
    public class Perfume
    {
        private int _id;
        private String _name;
        private decimal _price;
        private String _brand;

        public int id { get { return _id; } set { _id = value; } }
        public String name { get { return _name; } set { _name = value; } }
        public decimal price {
            get { return _price; } 
            set {
                if (promo != 0)
                {
                    _price = value - value * (decimal)promo;
                }
                else
                {
                    _price = value;
                }
             }
        }
        public String brand
        {
            get { return _brand; }
            set { _brand = value; }

        }
        public float promo { get; set; } = 0;   
    }
}
