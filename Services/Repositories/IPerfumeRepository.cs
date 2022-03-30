using DataAccess.Models;

namespace ParfumerieServices.Repositories
{
    public interface IPerfumeRepository
    {
        Task AddPerfume(Perfume perfume);
        Task DeletePerfume(Perfume perfume);
        Task<Perfume?> GetPerfume(Guid id);
        Task<IEnumerable<Perfume>> GetPerfumes();
        Task UpdatePerfume(Perfume perfume);
    }
}