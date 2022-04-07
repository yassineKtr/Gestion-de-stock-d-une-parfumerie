using Dapper;
using DataAccess.DbAccess;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Readers
{
    public interface IReadPerfume
    {
        Task<IEnumerable<Perfume>> GetPerfumes();
        Task<IEnumerable<Perfume>> GetPerfumesByBrand(string brand);
        Task<IEnumerable<string>> GetAllBrands();
        Task<Perfume?> GetPerfume(Guid id);
    }

    public class PerfumeReader : IReadPerfume
    {
        private readonly PostgreSqlConfiguration _configuration;
        private readonly IPostgreSqlConnection _buildPostgreSqlConnection;
        public PerfumeReader(IConfiguration config)
        {
            _configuration = new PostgreSqlConfiguration(config);
            _buildPostgreSqlConnection = new PostgreSqlConnection(_configuration);
        }
        
        public async Task<IEnumerable<Perfume>> GetPerfumes()
        {
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            var query = "SELECT * FROM perfumes";
            return await connection.QueryAsync<Perfume>(query, new{});
        }
        public async Task<IEnumerable<Perfume>> GetPerfumesByBrand(string brand)
        {
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            var query = "SELECT * FROM perfumes WHERE brand = @brand";
            return await connection.QueryAsync<Perfume>(query, new {brand = brand });
        }
        public async Task<IEnumerable<string>> GetAllBrands()
        {
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            var query = "SELECT DISTINCT(brand) FROM perfumes ORDER BY brand;";
            return await connection.QueryAsync<string>(query, new {});
        }
        
        public async Task<Perfume?> GetPerfume(Guid id)
        {
            var query = $"SELECT * FROM perfumes WHERE id = @id";
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Perfume>(query, new { id = id });
            return result.FirstOrDefault();
        }
    }
}
