using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionStockCDN.Models;


namespace GestionStockCDN.Project.Services
{
    public class Services
    {
        private IPerfumeRepository _perfumeRepository;
        private IShelfRepository _shelfRepository;
        public Services(IShelfRepository shelfRepository, IPerfumeRepository perfumeRepository)
        {
            _perfumeRepository = perfumeRepository;
            _shelfRepository = shelfRepository;

        }

        public bool addNewProduct(Perfume perfume)
        {
            if (_perfumeRepository.getPerfumeById(perfume.id)==null)
            {
                _perfumeRepository.addPerfume(perfume);
                if (_shelfRepository.getShelfByBrand(perfume.brand)!=null)
                {

                    _shelfRepository.getShelfByBrand(perfume.brand).perfumes.Add(perfume.id);
                }
                else
                {
                    var newShelf = new Shelf();
                    newShelf.brand = perfume.brand;
                    newShelf.perfumes= new List<int>(perfume.id);
                    




                    _shelfRepository.addShelf(newShelf);
                }
                 
                
                return true;
            }
            return false;
        }

        public bool deleteProduct(Perfume perfume)
        {
            if (_perfumeRepository.getPerfumeById(perfume.id) != null)
            {
                _shelfRepository.getShelfByBrand(perfume.brand).perfumes.Remove(perfume.id);
                _perfumeRepository.deletePerfume(perfume.id);
                

                return true;
            }

            return false;
        }

        public bool modifyProduct(Perfume perfume)
        {
            if(_perfumeRepository.getPerfumeById(perfume.id) != null)
            {
                _perfumeRepository.updatePerfume(perfume);
                
                return true;
            }
            return false;

        }

        public bool productAvailable(int perfumeId)
        {
            if (_perfumeRepository.getPerfumeById(perfumeId) != null)
            {
                return true;
            }

            return false;
        }

        public bool addDiscount(int perfumeId,double discountVal)
        {
            var perfumeToUpdate = _perfumeRepository.getPerfumeById(perfumeId) ;
            if (perfumeToUpdate != null)
            {
                perfumeToUpdate.promo = discountVal;
                perfumeToUpdate.price -= perfumeToUpdate.price * discountVal;
                return true;
            }
            return false;
        }




    }
}
