using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionStockCDN.Models;
using GestionStockCDN.DAL;
using Xunit;
using GestionStockCDN.Project.Services;


namespace GestionStockCDN.Tests
{
    public class ServicesTests
    {
        private  List<Shelf> shelves;
        private   List<Perfume> perfumes ; 
        private   IPerfumeRepository perfumeRepository;
        private   IShelfRepository shelfRepository ;
        private Services myService ;

        [Fact]
        public void ShouldAddNewProduct()
        {

            //Arange
            var testProduct = new Perfume
            {
                id = 1,
                name = "moqName",
                brand = "moqBrand"

            };
            perfumes = new List<Perfume>();
            shelves = new List<Shelf>();
            perfumeRepository = new PerfumeRepository(perfumes);
            shelfRepository = new ShelfRepository(shelves);
            myService = new Services(shelfRepository, perfumeRepository);
        
        
            //Act
            myService.addNewProduct(testProduct);

            //Assert
            Assert.Contains(shelves, p => p.brand == testProduct.brand);
            Assert.Contains(perfumes, p => p.brand == testProduct.brand);

        }
        [Fact]
        public void shouldDeleteProduct()
        {
            //Arrange
            //Arange
            var testProduct = new Perfume
            {
                id = 1,
                name = "moqName",
                brand = "moqBrand"

            };
            var testShelve = new Shelf
            {
                brand = "moqBrand",
                perfumes = new List<int>(1)
            };
            perfumes = new List<Perfume>();
            shelves = new List<Shelf>();
            perfumeRepository = new PerfumeRepository(perfumes);
            shelfRepository = new ShelfRepository(shelves);
            myService = new Services(shelfRepository, perfumeRepository);
            perfumes.Add(testProduct);
            shelves.Add(testShelve);


            //Act
             myService.deleteProduct(testProduct);
            //Assert 

            Assert.DoesNotContain(perfumes, p => p.id == testProduct.id);
            Assert.DoesNotContain(shelves, p => p.perfumes.Contains(testProduct.id));
        }
        
        


    }
}
