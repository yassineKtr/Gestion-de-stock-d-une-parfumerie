using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionStockCDN.Models
{
    public class ShelfRepository : IShelfRepository
    {
        private List<Shelf> _context;
        public ShelfRepository(List<Shelf> shelves)
        {
            _context = shelves;
        }
        public void addShelf(Shelf shelf)
        {
            _context.Add(shelf);
        }

        public void deleteShelf(String brand)
        {
            var shelfToRemove = _context.SingleOrDefault(r => r.brand == brand);
            _context.Remove(shelfToRemove);
        }

        public List<Shelf> getAllShelves()
        {
            return _context;
        }

        

        public void updateShelf(Shelf shelf)
        {
            var shelfToUpdate = _context.SingleOrDefault(r => r.brand == shelf.brand);
            //shelfToUpdate.brand = shelf.brand;
            shelfToUpdate.perfumes = shelf.perfumes;

        }

        public Shelf getShelfByBrand(string brand)
        {
            return _context.SingleOrDefault(r => r.brand == brand);
        }
    }
}
