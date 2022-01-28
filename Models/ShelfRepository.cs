using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_stock_d_une_parfumerie.DAL;

namespace Gestion_de_stock_d_une_parfumerie.Models
{
    public class ShelfRepository : IShelfRepository
    {
        private List<Shelf> _context;
        public ShelfRepository()
        {
            _context = DB.getInstance().shelves;
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
    }
}
