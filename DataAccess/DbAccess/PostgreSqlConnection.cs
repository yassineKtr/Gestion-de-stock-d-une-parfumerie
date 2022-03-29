using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbAccess
{
    public class PostgreSqlConnection : IPostgreSqlConnection
    {
        private readonly NpgsqlConnectionStringBuilder _connectionStringBuilder;

        public PostgreSqlConnection(PostgreSqlConfiguration configuration)
        {
            
            _connectionStringBuilder = new NpgsqlConnectionStringBuilder { 
                    Host= configuration.Host,
                    Port = configuration.Port,
                    Username = configuration.UserName, 
                    Database = configuration.DataBase, 
                    Password = configuration.Password };
        }


        public NpgsqlConnection GetSqlConnection()
        {
            return new(_connectionStringBuilder.ConnectionString);

        }
    }

    public interface IPostgreSqlConnection
    {
        NpgsqlConnection GetSqlConnection();

    }

    public class PostgreSqlConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public string UserName{ get; set; }
        public string DataBase { get; set; }
        public string Password { get; set; }
    }
}
