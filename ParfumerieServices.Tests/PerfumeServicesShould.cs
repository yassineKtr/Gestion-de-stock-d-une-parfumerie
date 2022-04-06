using Moq;
using ParfumerieServices.Repositories;
using ParfumerieServices.Services;
using System;
using System.Linq;
using Xunit;

namespace ParfumerieServices.Tests
{
    public class PerfumeServicesShould
    {
        [Fact]
        public void GetAllPerfumes()
        {
            //Arrange
            var mockResults = TestMethodes.GetPerfumes();
            var mockRepo= new Mock<IPerfumeRepository>();
            mockRepo.Setup(x => x.GetPerfumes()).Returns(mockResults);
            var expected = mockResults.Result.ToList();
            //Act
            var result = mockRepo.Object.GetPerfumes().Result.ToList();

            //Assert
            Assert.True(result.SequenceEqual(expected));
        }

        [Fact]
        public void GetPerfumeById()
        {
            //Arrange
            var mockResults = TestMethodes.GetPerfumeById();
            var perfumeToBeRetrieved = mockResults.Result;
            var mockRepo = new Mock<IPerfumeRepository>();
            mockRepo.Setup(x => x.GetPerfume(perfumeToBeRetrieved.id)).Returns(mockResults);
            var expected = perfumeToBeRetrieved;
            //Act
            var result = mockRepo.Object.GetPerfume(perfumeToBeRetrieved.id).Result;

            //Assert
            Assert.NotNull(result);
            Assert.True(expected.Equals(result));
        }


        [Fact]
        public void GetPerfumesByBrand()
        {
            //Arrange
            var mockResults = TestMethodes.GetPerfumesOfASingleBrand();

            var mockRepo = new Mock<IPerfumeServices>();
            mockRepo.Setup(x => x.GetPerfumesByBrand("brand1")).Returns(mockResults);
            var expected = mockResults.Result;
            //Act
            var result = mockRepo.Object.GetPerfumesByBrand("brand1").Result;

            //Assert
            Assert.True(expected.Equals(result));
        }

        [Fact]
        public void GetAllBrands()
        {
            //Arrange
            var mockResults = TestMethodes.GetBrands();
            
            var mockRepo = new Mock<IPerfumeServices>();
            mockRepo.Setup(x => x.GetAllBrands()).Returns(mockResults);
            var expected = mockResults.Result;
            //Act
            var result = mockRepo.Object.GetAllBrands().Result;

            //Assert
            Assert.True(expected.Equals(result));
        }

    }
}
