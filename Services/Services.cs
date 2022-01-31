using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_stock_d_une_parfumerie.Models;

namespace Gestion_de_stock_d_une_parfumerie.Services
{
    public class Services
    {
        IPerfumeRepository _perfumeRepository;
        IShelfRepository _shelfRepository;
        public Services(IShelfRepository shelfRepository, IPerfumeRepository perfumeRepository)
        {
            _perfumeRepository = perfumeRepository;
            _shelfRepository = shelfRepository;

        }

        bool addNewProduct(Perfume perfume)
        {
            if (_perfumeRepository.getPerfumeById(perfume.id)==null)
            {
                _perfumeRepository.addPerfume(perfume);
                 _shelfRepository.getShelfByBrand(perfume.brand).perfumes.Add(perfume.id);
                
                return true;
            }
            return false;
        }

        bool deleteProduct(Perfume perfume)
        {
            if (_perfumeRepository.getPerfumeById(perfume.id) != null)
            {
                _shelfRepository.getShelfByBrand(perfume.brand).perfumes.Remove(perfume.id);
                _perfumeRepository.deletePerfume(perfume.id);
                

                return true;
            }

            return false;
        }

        bool modifyProduct(Perfume perfume)
        {
            if(_perfumeRepository.getPerfumeById(perfume.id) != null)
            {
                _perfumeRepository.updatePerfume(perfume);
                return true;
            }
            return false;

        }

        bool productAvailable(int perfumeId)
        {
            if (_perfumeRepository.getPerfumeById(perfumeId) != null)
            {
                return true;
            }

            return false;
        }




    }
}
