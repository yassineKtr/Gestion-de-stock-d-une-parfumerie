using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PerfumeRepository
    {
        private readonly ISqlDataAccess _db;

        public PerfumeRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<Perfume>> GetPerfumes()
        {
            String sql = "SELECT * FROM perfumes";
            return _db.LoadData<Perfume, dynamic>(sql, new {});
        }
        //TODO: fix this 1:00:00
        public async Task<Perfume?> GetPerfume(Guid id)
        {
            String sql = $"SELECT * FROM perfumes WHERE id = {id}";
        }
    }
}
