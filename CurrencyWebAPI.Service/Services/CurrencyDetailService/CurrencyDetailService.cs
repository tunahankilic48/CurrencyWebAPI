using AutoMapper;
using CurrencyWebAPI.Business.Hubs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyVMs;
using CurrencyWebAPI.Domain.Entities;
using CurrencyWebAPI.Domain.Repositories;
using CurrencyWebAPI.Service.Services.CurrencyService;
using HtmlAgilityPack;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;


namespace CurrencyWebAPI.Service.Services.CurrencyDetailService
{
    internal class CurrencyDetailService : ICurrencyDetailService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyDetailRepository _currencyDetailRepository;
        private readonly ICurrencyService _currencyService;
        private readonly IHubContext<CurrencyHub> _hubContext;

        public CurrencyDetailService(IMapper mapper, ICurrencyDetailRepository currencyDetailRepository, ICurrencyService currencyService, IHubContext<CurrencyHub> hubContext)
        {
            _mapper = mapper;
            _currencyDetailRepository = currencyDetailRepository;
            _currencyService = currencyService;
            _hubContext = hubContext;
        }

        public async Task Create()
        {
            List<CurrencyVM> currencies = await _currencyService.GetAll();

            HtmlWeb web = new HtmlWeb();
            var doc = web.Load("https://kur.doviz.com/");
            var docNode = doc.DocumentNode;

            List<CurrencyDetail> currencyDetails = new List<CurrencyDetail>();

            foreach (CurrencyVM currency in currencies ) 
            {
                CurrencyDetail currencyDetail = new CurrencyDetail();
                currencyDetail.CurrencyId = currency.Id;
                currencyDetail.Date = DateTime.Now;
                currencyDetail.Value = (docNode.SelectSingleNode($"//td[@data-socket-key='{currency.AttributeName}'  and @data-socket-attr='ask']")).InnerText;
                currencyDetails.Add(currencyDetail);
            }


            await _currencyDetailRepository.AddRange(currencyDetails);
            await _hubContext.Clients.All.SendAsync("CurrentCurrencyValue", await GetLastValues());

        }

        public async Task DeleteCurrencyDetailInHour(int hour)
        {
            List<CurrencyDetail> currencyDetails = await _currencyDetailRepository.GetFilteredList(
                select: x => new CurrencyDetail()
                {
                    CurrencyId = x.CurrencyId,
                    Value = x.Value,
                    Date = x.Date
                },
                where: x => x.Date.Hour == hour,
                orderby: null,
                include: null
                );

            await _currencyDetailRepository.DeleteRange(currencyDetails);
        }

        public async Task<List<CurrencyDetailVM>> GetHourlyValues(int currencyId, int hour)
        {
            List<CurrencyDetailVM> currencyDetailVM = await _currencyDetailRepository.GetFilteredList(
                select: x => new CurrencyDetailVM()
                {
                    Value = x.Value
                },
                where: x => x.Date.Hour == hour && x.CurrencyId == currencyId,
                orderby: x => x.OrderByDescending(y => y.Value),
                include: null
                );
            return currencyDetailVM;
        }

        public async Task<CurrencyDetailVM> GetLastValue(int currencyId)
        {
            CurrencyDetailVM currencyDetailVM = await _currencyDetailRepository.GetFilteredFirstOrDefault(
                select: x => new CurrencyDetailVM()
                {
                    CurrencyName = x.Currency.Name,
                    Value = x.Value
                },
                where: x => x.CurrencyId == currencyId,
                orderby: x => x.OrderByDescending(y => y.Date),
                include: x => x.Include(y=> y.Currency)
                );
            return currencyDetailVM;
        }

        public async Task<List<CurrencyDetailVM>> GetLastValues()
        {
            List<CurrencyVM> currencies = await _currencyService.GetAll();

            List<CurrencyDetailVM> currencyDetails = new List<CurrencyDetailVM>();

            foreach (CurrencyVM currency in currencies)
            {
                currencyDetails.Add(await GetLastValue(currency.Id));
            }
            return currencyDetails;
        }
    }
}
