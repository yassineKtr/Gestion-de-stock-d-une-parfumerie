using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionStockCDN.DAL;

namespace GestionStockCDN.Models
{
    public class ShelfRepository : IShelfRepository
    {
        private List<Shelf> _context;
        public ShelfRepository(DB db)
        {
            _context = db.shelves;
        }
        public void addShelf(Shelf shelf)
        {
            _context.Add(shelf);
        }

        public void deleteShelf(int id)
        {
            var shelfToRemove = _context.SingleOrDefault(r => r.id == id);
            _context.Remove(shelfToRemove);
        }

        public List<Shelf> getAllShelves()
        {
            return _context;
        }

        public Shelf getShelfById(int id)
        {
            return _context.SingleOrDefault(r => r.id == id);

        }

        public void updateShelf(Shelf shelf)
        {
            var shelfToUpdate = _context.SingleOrDefault(r => r.id == shelf.id);
            shelfToUpdate.brand = shelf.brand;
            shelfToUpdate.perfumes = shelf.perfumes;

        }

        public Shelf getShelfByBrand(string brand)
        {
            return _context.SingleOrDefault(r => r.brand == brand);
        }
    }
}
