using DataAccess.Models;

namespace DataAccess.Writers;

public interface IWritePerfume
{
    Task AddPerfume(Perfume perfume);
    Task AddPromo(Guid perfumeId, double amount);
    Task UpdatePerfume(Perfume perfume);
    Task DeletePerfume(Guid perfumeId);
}