using DataAccess.Models;

namespace DataAccess.Readers;

public interface IReadPerfume
{
    Task AddPerfume(Perfume perfume);
    Task<IEnumerable<Perfume>> GetPerfumes();
    Task<IEnumerable<Perfume>> GetPerfumesByBrand(string brand);
    Task<IEnumerable<string>> GetAllBrands();
    Task AddPromo(Guid perfumeId, double amount);
    Task<Perfume?> GetPerfume(Guid id);
    Task UpdatePerfume(Perfume perfume);
    Task DeletePerfume(Guid perfumeId);
}