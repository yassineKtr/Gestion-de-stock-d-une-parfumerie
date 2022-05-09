using System.IO;
using AutoFixture;
using DataAccess.Models;
using DataAccess.Readers;
using DataAccess.Writers;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace DataAccess.Tests
{
    public class PerfumeWriterShould
    {
        private readonly IReadPerfume _perfumeReader;
        private readonly IWritePerfume _perfumeWriter;
        private readonly Fixture _fixture;
        private readonly IConfiguration _configuration;

        public PerfumeWriterShould()
        {
            _configuration = TestHelper.GetIConfigurationRoot(Directory.GetCurrentDirectory());
            _perfumeReader = new PerfumeReader(_configuration);
            _perfumeWriter = new PerfumeWriter(_configuration);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task AddPerfume()
        {
            //Arrange
            var sut = _fixture.Create<Perfume>();
            //Act
            await _perfumeWriter.AddPerfume(sut);
            //Assert
            var result = _perfumeReader.GetPerfume(sut.Id);
            var resultToBeTested = result.Result;
            Assert.NotNull(resultToBeTested);
        }
        [Fact]
        public async Task UpdatePerfume()
        {
            //Arrange
            var sut = _fixture.Create<Perfume>();
            await _perfumeWriter.AddPerfume(sut);
            //Act
            sut.Name = "Updated";
            await _perfumeWriter.UpdatePerfume(sut);
            //Assert
            var result = _perfumeReader.GetPerfume(sut.Id);
            var resultToBeTested = result.Result;
            Assert.Equal(sut.Name, resultToBeTested?.Name);
        }
        [Fact]
        public async Task DeletePerfume()
        {
            //Arrange
            var sut = _fixture.Create<Perfume>();
            await _perfumeWriter.AddPerfume(sut);
            //Act
            await _perfumeWriter.DeletePerfume(sut.Id);
            //Assert
            var result = _perfumeReader.GetPerfume(sut.Id);
            var resultToBeTested = result.Result;
            Assert.Null(resultToBeTested);
        }
        [Fact]
        public async Task AddPromo()
        {
            //Arrange
            var sut = _fixture.Build<Perfume>()
                .With(x => x.Promo, 0)
                .With(x => x.Price, 100)
                .Create();
            await _perfumeWriter.AddPerfume(sut);
            //Act
            await _perfumeWriter.AddPromo(sut.Id,0.25);
            //Assert
            var result = _perfumeReader.GetPerfume(sut.Id);
            var resultToBeTested = result.Result;
            Assert.Equal(expected: 0.25, resultToBeTested?.Promo);
            Assert.Equal(expected: 75, resultToBeTested?.Price);
        }

    }
}
