using AutoMapper;
using DynamicReport.InterfaceRepository;
using DynamicReportWebApi.Models;
using DynamicReportWebApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DynamicReport.Repository
{
    public class ReportingDataRepository : IReportingDataRepository
    {
        private readonly DynamicReportContext _context;
        private readonly IMapper _mapper;
        public ReportingDataRepository(IMapper mapper)
        {
            _context = new DynamicReportContext();
            _mapper = mapper;
        }

        public IEnumerable<string> GetReportingColumns()
        {
            return _context.ReportingData.Select(x => x.Question).Distinct().ToList();
        }

        public IEnumerable<MasterInformationViewModel> GetReportingData()
        {
            var data = new List<MasterInformationViewModel>();
            var result = _context.MasterInformations.Include(x => x.ReportingData).ToList();
            data = _mapper.Map<List<MasterInformationViewModel>>(result);
            return data;
        }
    }
}