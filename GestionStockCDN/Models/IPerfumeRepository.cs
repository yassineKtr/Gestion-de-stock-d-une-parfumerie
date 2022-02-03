using System.Collections.Generic;

namespace GestionStockCDN.Models
{
    public interface IPerfumeRepository
    {
        List<Perfume> getAllPerfumes();
        Perfume getPerfumeById(int id);
        void addPerfume(Perfume perfume);
        void updatePerfume(Perfume perfume);
        void deletePerfume(int id);
    }
}
