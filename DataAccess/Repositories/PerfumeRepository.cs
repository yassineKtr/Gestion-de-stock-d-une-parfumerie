using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PerfumeRepository : IPerfumeRepository
    {
        private readonly ISqlDataAccess _db;

        public PerfumeRepository(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task AddPerfume(Perfume perfume)
        {
            var sql = "INSERT INTO perfumes (id,name,brand,promo,price) VALUES (@id,@name,@brand,@promo,@price)";
            var parameters = new
            {
                id = perfume.id,
                name = perfume.name,
                brand = perfume.brand,
                promo = perfume.promo,
                price = perfume.price,
            };
            return _db.SaveData(sql, parameters);

        }

        public Task<IEnumerable<Perfume>> GetPerfumes()
        {
            var sql = "SELECT * FROM perfumes";
            return _db.LoadData<Perfume, dynamic>(sql, new { });
        }
        public async Task<Perfume?> GetPerfume(Guid id)
        {
            var sql = $"SELECT * FROM perfumes WHERE id = @id";
            var queryArgs = new { id = id };
            var result = await _db.LoadData<Perfume, dynamic>(sql, queryArgs);
            return result.FirstOrDefault();
        }

        public Task UpdatePerfume(Perfume perfume)
        {
            var sql = "UPDATE perfumes " +
                "SET name =@name," +
                "brand =@brand," +
                "promo =@promo," +
                "price =@price" +
                "WHERE id=@id";
            var parameters = new
            {
                id = perfume.id,
                name = perfume.name,
                brand = perfume.brand,
                promo = perfume.promo,
                price = perfume.price
            };
            return _db.SaveData(sql, parameters);
        }

        public Task DeletePerfume(Perfume perfume)
        {
            var sql = "DELETE FROM perfumes WHERE id = @id";
            return _db.SaveData(sql, new { id = perfume.id });
        }
    }
}
