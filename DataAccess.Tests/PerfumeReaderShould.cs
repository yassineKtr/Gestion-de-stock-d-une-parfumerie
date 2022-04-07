using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Dapper;
using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Readers;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace DataAccess.Tests
{
    public class PerfumeReaderShould
    {
        private readonly PostgreSqlConfiguration _configuration ;
        private readonly IPostgreSqlConnection _buildPostgreSqlConnection;
        private readonly IReadPerfume _perfumeReader;
        private readonly Fixture _fixture;
        private readonly IConfiguration config;

        public PerfumeReaderShould()
        {
            config = new ConfigurationBuilder()
                .AddJsonFile(@"./appsettings.json")
                .AddJsonFile($"appsettings.developement.json", optional: true)
                .Build();
            _configuration = new PostgreSqlConfiguration(config);
            _buildPostgreSqlConnection = new PostgreSqlConnection(_configuration);
            _perfumeReader = new PerfumeReader(config);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task AddPerfume()
        {
            //Arrange
            var sut = _fixture.Create<Perfume>();
            //Act
            await _perfumeReader.AddPerfume(sut);
            //Assert
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            var query = $"SELECT * FROM perfumes WHERE id = @id";
            var result = await connection.QueryAsync<Perfume>(query, new { id = sut.id });
            var resultToBeTested = result.FirstOrDefault();
            Assert.NotNull(resultToBeTested);
        }


    }
}
