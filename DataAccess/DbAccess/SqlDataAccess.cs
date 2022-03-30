using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        
        private  readonly PostgreSqlConfiguration _configuration;
        private  readonly IPostgreSqlConnection _buildPostgreSqlConnection;

        public SqlDataAccess(IConfiguration config)
        {
            _configuration = new PostgreSqlConfiguration(config);
            _buildPostgreSqlConnection = new PostgreSqlConnection(_configuration);
        }
        
        public async Task<IEnumerable<T>> LoadData<T,U>(
            string query,
            U parameters
            )
        {
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync<T>(query, parameters);
        }

        public async Task SaveData<T>(
            string query,
            T parameters
            )
        {
            await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
            await connection.OpenAsync();
            await connection.ExecuteAsync(query, parameters);

        }
    }
}
