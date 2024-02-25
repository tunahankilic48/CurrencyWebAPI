using AutoMapper;
using CurrencyWebAPI.Business.Models.DTOs.CurrencyDetailDTOs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebAPI.Domain.Entities;
using CurrencyWebAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CurrencyWebAPI.Service.Services.CurrencyDetailService
{
    internal class CurrencyDetailService : ICurrencyDetailService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyDetailRepository _currencyDetailRepository;

        public CurrencyDetailService(IMapper mapper, ICurrencyDetailRepository currencyDetailRepository)
        {
            _mapper = mapper;
            _currencyDetailRepository = currencyDetailRepository;
        }

        public async Task Create(CreateCurrencyDetailDTO createCurrencyDetailDTO)
        {
            CurrencyDetail currencyDetail = _mapper.Map<CurrencyDetail>(createCurrencyDetailDTO);
            await _currencyDetailRepository.Add(currencyDetail);

        }

        public async Task<CurrencyDetailVM> GetLastValue(int currencyId)
        {
            CurrencyDetailVM currencyDetailVM = await _currencyDetailRepository.GetFilteredFirstOrDefault(
                select: x => new CurrencyDetailVM()
                {
                    CurrencyName = x.Currency.Name,
                    Value = x.Value
                },
                where: null,
                orderby: x => x.OrderByDescending(y => y.Date),
                include: x => x.Include(y=> y.Currency)
                );
            return currencyDetailVM;
        }
    }
}
