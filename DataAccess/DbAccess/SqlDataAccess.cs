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
        private  PostgreSqlConfiguration _configuration;
        private  IPostgreSqlConnection _buildPostgreSqlConnection;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
            _configuration =  new PostgreSqlConfiguration { Host = _config.GetSection("ConnectionParams")["host"],
                                                            Port = Int32.Parse(_config.GetSection("ConnectionParams")["port"]),
                                                            UserName = _config.GetSection("ConnectionParams")["username"],
                                                            DataBase = _config.GetSection("ConnectionParams")["database"],
                                                            Password = _config.GetSection("ConnectionParams")["password"]
            };
        }
        
        public async Task<IEnumerable<T>> LoadData<T,U>(
            string query,
            U parameters,
            string connectionString = "Default")
        {
            //using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionString));
            _buildPostgreSqlConnection = new PostgreSqlConnection(_configuration);
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync<T>(query, parameters);
        }

        public async Task SaveData<T>(
            string query,
            T parameters,
            string connectionString = "Default")
        {
            //using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionString));
            _buildPostgreSqlConnection = new PostgreSqlConnection(_configuration);
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            await connection.ExecuteAsync(query, parameters);

        }
    }
}
