using System;
using System.Collections.Generic;

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
