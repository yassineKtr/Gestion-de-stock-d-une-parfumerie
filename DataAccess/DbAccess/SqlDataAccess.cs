using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            String query,
            U parameters,
            String connectionString = "Default")
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionString));
            return await connection.QueryAsync<T>(query, parameters);
        }

        public async Task SaveData<T>(
            String query,
            T parameters,
            String connectionString = "Default")
        {
            using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionString));
            await connection.ExecuteAsync(query, parameters);

        }
    }
}
