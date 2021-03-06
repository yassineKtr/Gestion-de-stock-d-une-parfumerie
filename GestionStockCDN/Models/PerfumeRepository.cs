using System.Collections.Generic;
using System.Linq;

namespace GestionStockCDN.Models
{
    public class PerfumeRepository : IPerfumeRepository
    {
        private List<Perfume> _context;
        public PerfumeRepository(List<Perfume> perfumes)
        {
            _context = perfumes;
        }
        public void addPerfume(Perfume perfume)
        {
            _context.Add(perfume);
        }

        public void deletePerfume(int id)
        {
            var perfumeToRemove = _context.SingleOrDefault(r => r.id == id);
            _context.Remove(perfumeToRemove);
        }

        public List<Perfume> getAllPerfumes()
        {
            return _context;
        }

        public Perfume getPerfumeById(int id)
        {
            return _context.SingleOrDefault(r => r.id == id);
        }

        public void updatePerfume(Perfume perfume)
        {
            var perfumeToUpdate = _context.SingleOrDefault(r => r.id == perfume.id);
            perfumeToUpdate.name = perfume.name;
            perfumeToUpdate.price = perfume.price;
        }
    }
}
