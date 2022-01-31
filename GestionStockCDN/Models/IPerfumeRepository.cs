using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
