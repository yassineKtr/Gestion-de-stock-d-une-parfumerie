using Dapper;
using DataAccess.DbAccess;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Writers
{
    public class PerfumeWriter : IWritePerfume
    {
        private readonly PostgreSqlConfiguration _configuration;
        private readonly IPostgreSqlConnection _buildPostgreSqlConnection;
        public PerfumeWriter(IConfiguration config)
        {
            _configuration = new PostgreSqlConfiguration(config);
            _buildPostgreSqlConnection = new PostgreSqlConnection(_configuration);
        }
        public async Task AddPerfume(Perfume perfume)
        {
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            var query = "INSERT INTO perfumes (id,name,brand,promo,price) VALUES (@id,@name,@brand,@promo,@price)";
            var parameters = new
            {
                id = perfume.id,
                name = perfume.name,
                brand = perfume.brand,
                promo = perfume.promo,
                price = perfume.price,
            };
            await connection.ExecuteAsync(query, parameters);
        }
        public async Task AddPromo(Guid perfumeId, double amount)
        {
            var query = $"SELECT * FROM perfumes WHERE id = @id";
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Perfume>(query, new { id = perfumeId });
            var targetPerfume = result.FirstOrDefault();
            var newPrice = targetPerfume.price;
            var newPromo = targetPerfume.promo;
            if (targetPerfume.promo != 0) newPrice /= (1 - targetPerfume.promo);
            newPromo = amount;
            newPrice *= (1 - amount);
            var updateQuery = "UPDATE perfumes " +
                              "SET promo = @promo, " +
                              "price = @price " +
                              "WHERE id = @id";
            var parameters = new
            {
                promo = newPromo,
                price = newPrice,
                id = perfumeId,
            };
            await connection.ExecuteAsync(updateQuery, parameters);
        }
        public async Task UpdatePerfume(Perfume perfume)
        {
            var query = "UPDATE perfumes " +
                        "SET name = @name, " +
                        "brand = @brand, " +
                        "promo = @promo, " +
                        "price = @price " +
                        "WHERE id = @id";
            var parameters = new
            {
                name = perfume.name,
                brand = perfume.brand,
                promo = perfume.promo,
                price = perfume.price,
                id = perfume.id,
            };
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            await connection.ExecuteAsync(query, parameters);
        }
        public async Task DeletePerfume(Guid perfumeId)
        {
            var query = "DELETE FROM perfumes WHERE id = @id";
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            await connection.ExecuteAsync(query, new { id = perfumeId });
        }
    }
}
