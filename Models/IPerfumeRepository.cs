using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_stock_d_une_parfumerie.Models
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
