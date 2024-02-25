using CurrencyWebAPI.Business.Models.DTOs.CurrencyDTOs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyVMs;

namespace CurrencyWebAPI.Service.Services.CurrencyService
{
    public interface ICurrencyService
    {
        Task Create(CreateCurrencyDTO createCurrencyDTO);
        Task Update(UpdateCurrencyDTO updateCurrencyDTO);
        Task Delete(int id);
        Task<CurrencyVM> GetById(int id);
        Task<List<CurrencyVM>> GetAll();

    }
}
