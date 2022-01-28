using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_stock_d_une_parfumerie.Models
{
    public class Shelf
    {
        private int _id;
        private String _brand;
        private List<int> _perfumes;

        public int id { get { return _id; } set { _id = id; } }
        public String brand { get { return _brand; } set { _brand = brand; } }
        public List<int> perfumes { get { return _perfumes; } set { _perfumes = perfumes; } }




    }
}
