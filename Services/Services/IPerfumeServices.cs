using DataAccess.Models;

namespace ParfumerieServices.Services;

public interface IPerfumeServices
{
    Task<IEnumerable<Perfume>> GetPerfumesByBrand(string brand);
    Task<IEnumerable<string>> GetAllBrands();
    Task<Task> AddPromo(Guid perfumeId, double amount);
    Task<IEnumerable<Perfume>> GetAllPerfumes();
    Task<Perfume?> GetPerfume(Guid id);
    Task AddPerfume(Perfume perfume);
    Task RemovePerfume(Perfume perfume);
    Task UpdatePerfume(Perfume perfume);
}