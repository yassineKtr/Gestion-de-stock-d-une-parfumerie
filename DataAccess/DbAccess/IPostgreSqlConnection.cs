using Npgsql;

namespace DataAccess.DbAccess;
public interface IPostgreSqlConnection
{
    NpgsqlConnection GetSqlConnection();
}