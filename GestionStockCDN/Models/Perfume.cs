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
        private double _price;
        private String _brand;

        public int id { get { return _id; } set { _id = value; } }
        public String name { get { return _name; } set { _name = value; } }
        
        public String brand
        {
            get { return _brand; }
            set { _brand = value; }

        }
        public double promo { get; set; } = 0;
        public double price { get => _price; set => _price = value; }
    }
}
