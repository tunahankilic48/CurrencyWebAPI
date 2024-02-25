using AutoMapper;
using CurrencyWebAPI.Business.Models.DTOs.CurrencyDetailDTOs;
using CurrencyWebAPI.Business.Models.DTOs.CurrencyDTOs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyVMs;
using CurrencyWebAPI.Domain.Entities;

namespace CurrencyWebAPI.Business.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Currency, CreateCurrencyDTO>().ReverseMap();
            CreateMap<Currency, UpdateCurrencyDTO>().ReverseMap();
            CreateMap<Currency, CurrencyVM>().ReverseMap();

            CreateMap<CurrencyDetail, CreateCurrencyDetailDTO>().ReverseMap();
            CreateMap<CurrencyDetail, CurrencyDetailVM>().ReverseMap();
        }
    }
}
