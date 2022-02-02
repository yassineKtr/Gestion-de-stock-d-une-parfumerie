using System.Collections.Generic;
using GestionStockCDN.Models;
using GestionStockCDN.Project.Services;
using Xunit;


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
                brand = "moqBrand",
                price = 10

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
                brand = "moqBrand",
                price = 10,

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

        [Fact]
        public void shouldUpdateProduct()
        {
            //Arrange
            var testProduct = new Perfume
            {
                id = 1,
                name = "moqName",
                brand = "moqBrand",
                price = 10

            };
            var newTestProduct = new Perfume
            {
                id = 1,
                name = "NewMoqName",
                brand = "moqBrand",
                price = 100

            };
            
            perfumes = new List<Perfume>();
            perfumeRepository = new PerfumeRepository(perfumes);
            shelfRepository = new ShelfRepository(shelves);
            myService = new Services(shelfRepository, perfumeRepository);
            perfumes.Add(testProduct);
            //Act
            myService.modifyProduct(newTestProduct);
            //Assert
            Assert.Contains(perfumes, p=>p.price==100);
            Assert.DoesNotContain(perfumes, p => p.price == 10);
        }

        [Fact]
        public void ShouldCheckIfProductIsAvailable()
        {
            //Arrange
            var testProduct = new Perfume
            {
                id = 1,
                name = "moqName",
                brand = "moqBrand",
                price = 10

            };
            perfumes = new List<Perfume>();
            shelves = new List<Shelf>();
            perfumeRepository = new PerfumeRepository(perfumes);
            shelfRepository = new ShelfRepository(shelves);
            myService = new Services(shelfRepository, perfumeRepository);
            perfumes.Add(testProduct);
            //Act
            var result = myService.productAvailable(testProduct.id);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldAddDiscount()
        {
            //Arrange
            var testProduct = new Perfume
            {
                id = 1,
                name = "moqName",
                brand = "moqBrand",
                price = 10

            };
            perfumes = new List<Perfume>();
            shelves = new List<Shelf>();
            perfumeRepository = new PerfumeRepository(perfumes);
            shelfRepository = new ShelfRepository(shelves);
            myService = new Services(shelfRepository, perfumeRepository);
            perfumes.Add(testProduct);
            //Act
            myService.addDiscount(testProduct.id, 0.1);
            //Assert
            Assert.Contains(perfumes, p => p.price == 9);
        }




    }
}
