using AutoMapper;
using DynamicReportWebApi.Models;
using DynamicReportWebApi.ViewModel;

namespace DynamicReportWebApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<MasterInformation,
                MasterInformationViewModel>().ReverseMap();
            CreateMap<MasterInformationViewModel,
                MasterInformation>().ReverseMap();

            CreateMap<ReportingDatum,
                ReportingDataViewModel>().ReverseMap();
            CreateMap<ReportingDataViewModel,
                ReportingDatum>().ReverseMap();

        }
    }
}
