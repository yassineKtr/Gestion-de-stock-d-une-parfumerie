
namespace DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string query, U parameters, string connectionString = "Default");
        Task SaveData<T>(string query, T parameters, string connectionString = "Default");
    }
}