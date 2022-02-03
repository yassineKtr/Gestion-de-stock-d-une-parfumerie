using System.Collections.Generic;
using GestionStockCDN.Models;
using Xunit;

namespace GestionStockCDN.Tests
{
    public class ShelfRepositoryTests
    {
        private IShelfRepository _shelfRepository;
        private List<Shelf> _shelves;

        [Fact]
        public void ShouldAddShelf()
        {
            //Arrange
            _shelves = new List<Shelf>();
            _shelfRepository = new ShelfRepository(_shelves);
            var testProduct = new Shelf()
            {
                brand = "moqBrand",
                perfumes = new List<int> { 1,2,3}
            };
            //Act
            _shelfRepository.addShelf(testProduct);
            //Assert
            Assert.Contains(_shelves, p => p.brand == testProduct.brand);
        }
        [Fact]
        public void ShouldDeleteShelf()
        {
            //Arrange
            _shelves = new List<Shelf>();
            _shelfRepository = new ShelfRepository(_shelves);
            var testProduct = new Shelf()
            {
                brand = "moqBrand",
                perfumes = new List<int> { 1, 2, 3 }
            };
            _shelves.Add(testProduct);
            //Act
            _shelfRepository.deleteShelf(testProduct.brand);
            //Assert
            Assert.DoesNotContain(_shelves, p => p.brand == testProduct.brand);

        }

        [Fact]
        public void ShouldGetAllPerfumes()
        {
            //Arrange
            _shelves = new List<Shelf>();
            _shelfRepository = new ShelfRepository(_shelves);
            var testProduct1 = new Shelf()
            {
                brand = "moqBrand",
                perfumes = new List<int> { 1, 2, 3 }
            };
            var testProduct2 = new Shelf()
            {
                brand = "moqBrand1",
                perfumes = new List<int> { 4, 5, 6 }
            };
            _shelves.Add(testProduct1);
            _shelves.Add(testProduct2);

            //Act
            var result = _shelfRepository.getAllShelves();

            //Assert
            Assert.Contains(result, p => p.brand == testProduct1.brand);
            Assert.Contains(result, p => p.brand == testProduct2.brand);

        }


        [Fact]
        public void ShouldGetShelfBrand()
        {
            //Arrange
            _shelves = new List<Shelf>();
            _shelfRepository = new ShelfRepository(_shelves);
            var testProduct1 = new Shelf()
            {
                brand = "moqBrand",
                perfumes = new List<int> { 1, 2, 3 }
            };
            var testProduct2 = new Shelf()
            {
                brand = "moqBrand1",
                perfumes = new List<int> { 4, 5, 6 }
            };
            _shelves.Add(testProduct1);
            _shelves.Add(testProduct2);
            
            //Act
            var result1 = _shelfRepository.getShelfByBrand(testProduct1.brand);
            var result2 = _shelfRepository.getShelfByBrand(testProduct2.brand);
            //Assert
            Assert.Equal(testProduct1, result1);
            Assert.Equal(testProduct2, result2);
        }

        [Fact]
        public void ShouldUpdatePerfume()
        {
            //Arrange
            _shelves = new List<Shelf>();
            _shelfRepository = new ShelfRepository(_shelves);
            var testProduct1 = new Shelf()
            {
                brand = "moqBrand",
                perfumes = new List<int> { 1, 2, 3 }
            };
            var testProduct2 = new Shelf()
            {
                brand = "moqBrand",
                perfumes = new List<int> { 4, 5, 6 }
            };
            _shelves.Add(testProduct1);

            //Act
            _shelfRepository.updateShelf(testProduct2);
            //Assert
            Assert.Contains(_shelves, p => p.perfumes == testProduct2.perfumes);


        }
    }
}
