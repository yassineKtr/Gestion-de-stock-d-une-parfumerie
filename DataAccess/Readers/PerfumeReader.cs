using DataAccess.DbAccess;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Readers
{
    public class PerfumeReader : IReadPerfume
    {
        private readonly IPostgresqlServices _postgresqlServices;
        public PerfumeReader(IConfiguration config)
        {
            _postgresqlServices = new PostgresqlServices(config);
        }
      
        public async Task<IEnumerable<Perfume>?> GetPerfumes()
        {
            var query = "SELECT * FROM perfumes";
            return await _postgresqlServices.QueryDb<Perfume>(query, new { });
        }
        public async Task<IEnumerable<Perfume>?> GetPerfumesByBrand(string brand)
        {
            var query = "SELECT * FROM perfumes WHERE brand = @brand";
            return await _postgresqlServices.QueryDb<Perfume>(query, new {brand = brand });
        }
        public async Task<IEnumerable<string>?> GetAllBrands()
        {
            var query = "SELECT DISTINCT(brand) FROM perfumes ORDER BY brand;";
            return await _postgresqlServices.QueryDb<string>(query, new {});
        }
        public async Task<Perfume?> GetPerfume(Guid id)
        {
            var query = $"SELECT * FROM perfumes WHERE id = @id";
            var result = await _postgresqlServices.QueryDb<Perfume>(query, new { id = id });
            return result?.FirstOrDefault();
        }
    }
}
