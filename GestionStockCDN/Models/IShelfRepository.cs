using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockCDN.Models
{
    public interface IShelfRepository
    {
        List<Shelf> getAllShelves();
        void addShelf(Shelf shelf);
        
        Shelf getShelfByBrand(String brand);
        void updateShelf(Shelf shelf);
        void deleteShelf(String brand);
    }
}
