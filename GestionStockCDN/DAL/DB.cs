using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionStockCDN.Models;

namespace GestionStockCDN.DAL
{
    public  class DB 
    {
        private static readonly DB _instance = new DB();
        public List<Shelf> shelves;
        public List<Perfume> perfumes;

        private DB()
        {
            shelves = new List<Shelf>();
            perfumes = new List<Perfume>();

        }

        public static DB getInstance()
        {
            return _instance;
        }
    }
}
