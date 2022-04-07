﻿using Npgsql;

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
        public NpgsqlConnection GetSqlConnection() => new(_connectionStringBuilder.ConnectionString);

    }

    

   
}
