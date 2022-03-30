using DataAccess.Models;
using ParfumerieServices.Repositories;

namespace ParfumerieServices.Services
{
    public class PerfumeServices : IPerfumeServices
    {
    private readonly IPerfumeRepository _perfumeRepository;

    public PerfumeServices(IPerfumeRepository repository)
    {
        _perfumeRepository = repository;
    }

    public async Task<IEnumerable<Perfume>> GetPerfumesByBrand(string brand)
    {
        var perfumes = await _perfumeRepository.GetPerfumes();
        var result = perfumes.Where(perfume => perfume.brand == brand);
        return result;

    }

    public async Task<IEnumerable<string>> GetAllBrands()
    {
        var perfumes = await _perfumeRepository.GetPerfumes();
        var result = perfumes.Select(x => x.brand);
        return result;
    }

    public async Task<Task> AddPromo(Guid perfumeId, double amount)
    {
        var targetPerfume = await _perfumeRepository.GetPerfume(perfumeId);
        if (targetPerfume.promo != 0) targetPerfume.price /= (1 - targetPerfume.promo);
        targetPerfume.promo = amount;
        targetPerfume.price *= (1-amount);
       
        return _perfumeRepository.UpdatePerfume(targetPerfume);
    }


    public async Task<IEnumerable<Perfume>> GetAllPerfumes() => await _perfumeRepository.GetPerfumes();
    public async Task<Perfume?> GetPerfume(Guid id) => await _perfumeRepository.GetPerfume(id);
    public async Task AddPerfume(Perfume perfume) => await _perfumeRepository.AddPerfume(perfume);
    public async Task RemovePerfume(Perfume perfume) => await _perfumeRepository.DeletePerfume(perfume);
    public async Task UpdatePerfume(Perfume perfume) => await _perfumeRepository.UpdatePerfume(perfume);






    }
}
