using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_stock_d_une_parfumerie.Models
{
    public interface IShelfRepository
    {
        List<Shelf> getAllShelves();
        void addShelf(Shelf shelf);
        Shelf getShelfById(int id);
        void updateShelf(Shelf shelf);
        void deleteShelf(int id);
    }
}
