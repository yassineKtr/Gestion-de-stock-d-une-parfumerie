using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DbAccess
{
    public class PostgresqlServices : IPostgresqlServices
    {
        private readonly PostgreSqlConfiguration _configuration;
        private readonly IPostgreSqlConnection _buildPostgreSqlConnection;
        public PostgresqlServices(IConfiguration config)
        {
            _configuration = new PostgreSqlConfiguration(config);
            _buildPostgreSqlConnection = new PostgreSqlConnection(_configuration);
        }

        public async Task<IEnumerable<T>?> QueryDb<T>(string query, Object param)
        {
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync<T>(query, param);
        }

        public async Task Execute(string query, Object param)
        {
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            await connection.ExecuteAsync(query, param);
        }
    }
}
