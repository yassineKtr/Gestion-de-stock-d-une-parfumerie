using System;

namespace GestionStockCDN.Models
{
    public class Perfume
    {
        public Guid id { get; set; }
        public String name { get ; set ;}     
        public String brand { get;set;}
        public double promo { get; set; } = 0;
        public double price { get; set; }
    }
}
