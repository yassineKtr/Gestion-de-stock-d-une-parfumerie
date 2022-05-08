using DataAccess.Models;

namespace DataAccess.Readers;

public interface IReadPerfume
{
    Task<IEnumerable<Perfume>?> GetPerfumes();
    Task<IEnumerable<Perfume>?> GetPerfumesByBrand(string brand);
    Task<IEnumerable<string>?> GetAllBrands();
    Task<Perfume?> GetPerfume(Guid id);
}