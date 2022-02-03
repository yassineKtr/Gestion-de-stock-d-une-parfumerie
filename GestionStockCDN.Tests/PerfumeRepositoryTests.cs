using System.Collections.Generic;
using GestionStockCDN.Models;
using Xunit;

namespace GestionStockCDN.Tests
{
    public class PerfumeRepositoryTests
    {
        private IPerfumeRepository _perfumeRepository;
        private List<Perfume> _perfumes;
        [Fact]
        public void ShouldAddPerfume()
        {
            //Arrange
            _perfumes = new List<Perfume>();
            _perfumeRepository = new PerfumeRepository(_perfumes);
            var testProduct = new Perfume()
            {
                brand = "moqBrand",
                id = 1,
                price = 10
            };
            //Act
            _perfumeRepository.addPerfume(testProduct);
            //Assert
            Assert.Contains(_perfumes, p =>p.id == testProduct.id);
        }
        [Fact]
        public void ShouldDeletePerfume()
        {
            //Arrange
            _perfumes = new List<Perfume>();
            _perfumeRepository = new PerfumeRepository(_perfumes);
            var testProduct = new Perfume()
            {
                brand = "moqBrand",
                id = 1,
                price = 10
            };
            _perfumes.Add(testProduct);
            //Act
            _perfumeRepository.deletePerfume(testProduct.id);
            //Assert
            Assert.DoesNotContain(_perfumes, p => p.id == testProduct.id);

        }

        [Fact]
        public void ShouldGetAllPerfumes()
        {
            //Arrange
            _perfumes = new List<Perfume>();
            _perfumeRepository = new PerfumeRepository(_perfumes);
            var testProduct1 = new Perfume()
            {
                brand = "moqBrand",
                id = 1,
                price = 10
            };
            var testProduct2 = new Perfume()
            {
                brand = "moqBrand1",
                id = 2,
                price = 10
            };
            _perfumes.Add(testProduct1);
            _perfumes.Add(testProduct2);

            //Act
            var result = _perfumeRepository.getAllPerfumes();

            //Assert
            Assert.Contains(result, p => p.id == testProduct1.id);
            Assert.Contains(result, p => p.id == testProduct2.id);

        }


        [Fact]
        public void ShouldGetProductById()
        {
            //Arrange
            _perfumes = new List<Perfume>();
            _perfumeRepository = new PerfumeRepository(_perfumes);
            var testProduct1 = new Perfume()
            {
                brand = "moqBrand",
                id = 1,
                price = 10
            };
            var testProduct2 = new Perfume()
            {
                brand = "moqBrand1",
                id = 2,
                price = 10
            };
            _perfumes.Add(testProduct1);
            _perfumes.Add(testProduct2);
            //Act
            var result1 = _perfumeRepository.getPerfumeById(1);
            var result2 = _perfumeRepository.getPerfumeById(2);
            //Assert
            Assert.Equal(testProduct1, result1);
            Assert.Equal(testProduct2, result2);
        }

        [Fact]
        public void ShouldUpdatePerfume()
        {
            //Arrange
            _perfumes = new List<Perfume>();
            _perfumeRepository = new PerfumeRepository(_perfumes);
            var testProduct1 = new Perfume()
            {
                name = "moqName",
                brand = "moqBrand",
                id = 1,
                price = 10
            };
            var testProduct2 = new Perfume()
            { 
                name = "moqName1",
                brand = "moqBrand",
                id = 1,
                price = 10
            };
            _perfumes.Add(testProduct1);

            //Act
            _perfumeRepository.updatePerfume(testProduct2);
            //Assert
            Assert.Contains(_perfumes, p=> p.name == "moqName1");


        }
    }
}
