using AutoMapper;
using CurrencyWebAPI.Business.Models.DTOs.CurrencyDTOs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyVMs;
using CurrencyWebAPI.Domain.Entities;
using CurrencyWebAPI.Domain.Repositories;

namespace CurrencyWebAPI.Service.Services.CurrencyService
{
    internal class CurrencyService : ICurrencyService
    {
        public readonly IMapper _mapper;
        public readonly ICurrencyRepository _currencyRepository;
        public CurrencyService(IMapper mapper, ICurrencyRepository currencyRepository)
        {
            _mapper = mapper;
            _currencyRepository = currencyRepository;
        }
        public async Task Create(CreateCurrencyDTO createCurrencyDTO)
        {
            bool hasCurrency = await _currencyRepository.Any(x => x.Name == createCurrencyDTO.Name);
            if (!hasCurrency)
            {
                Currency currency = _mapper.Map<Currency>(createCurrencyDTO);
                await _currencyRepository.Add(currency);
            }

        }

        public async Task Delete(int id)
        {
            Currency currency = await _currencyRepository.GetDefault(x => x.Id == id);
            if (currency is not null)
            {
                await _currencyRepository.Delete(currency);
            }
        }

        public async Task<List<CurrencyVM>> GetAll()
        {
            List<Currency> currencies = await _currencyRepository.GetDefaults(x => x.Name != null);
            List<CurrencyVM> currenciesVm = _mapper.Map<List<CurrencyVM>>(currencies);
            return currenciesVm;
        }

        public async Task<CurrencyVM> GetById(int id)
        {
            Currency currency = await _currencyRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<CurrencyVM>(currency);
        }

        public async Task Update(UpdateCurrencyDTO updateCurrencyDTO)
        {
            Currency currency = _mapper.Map<Currency>(updateCurrencyDTO); 
            await _currencyRepository.Update(currency);
        }
    }
}
