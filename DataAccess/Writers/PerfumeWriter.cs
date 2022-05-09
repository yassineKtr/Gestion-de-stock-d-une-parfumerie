using DataAccess.DbAccess;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Writers
{
    public class PerfumeWriter : IWritePerfume
    {
        private readonly IPostgresqlServices _postgresqlServices;
        public PerfumeWriter(IConfiguration config)
        {
            _postgresqlServices = new PostgresqlServices(config);
        }
        public async Task AddPerfume(Perfume perfume)
        {
            var query = "INSERT INTO perfumes (id,name,brand,promo,price) VALUES (@id,@name,@brand,@promo,@price)";
            var parameters = new
            {
                id = perfume.Id,
                name = perfume.Name,
                brand = perfume.Brand,
                promo = perfume.Promo,
                price = perfume.Price,
            };
            await _postgresqlServices.Execute(query, parameters);
        }
        public async Task AddPromo(Guid perfumeId, double amount)
        {
            var query = $"SELECT * FROM perfumes WHERE id = @id";
            var result = await _postgresqlServices.QueryDb<Perfume>(query, new { id = perfumeId });
            var targetPerfume = result?.FirstOrDefault();
            var newPrice = targetPerfume?.Price;
            var newPromo = targetPerfume?.Promo;
            if (targetPerfume?.Promo != 0) newPrice /= (1 - targetPerfume?.Promo);
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
            await _postgresqlServices.Execute(updateQuery, parameters);
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
                name = perfume.Name,
                brand = perfume.Brand,
                promo = perfume.Promo,
                price = perfume.Price,
                id = perfume.Id,
            };
            await _postgresqlServices.Execute(query, parameters);
        }
        public async Task DeletePerfume(Guid perfumeId)
        {
            var query = "DELETE FROM perfumes WHERE id = @id";
            await _postgresqlServices.Execute(query, new { id = perfumeId });
        }
    }
}
