using AutoMapper;
using DynamicReport.InterfaceRepository;
using DynamicReport.Repository;
using DynamicReportWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace DynamicReportWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportingDataController : ControllerBase
    {
        private IReportingDataRepository _reportingDataRepository;
        private readonly IMapper _mapper;

        public ReportingDataController(IMapper mapper)
        {
            _reportingDataRepository = new ReportingDataRepository(mapper);
        }

        [HttpGet("GetReportingColumns")]
        public IActionResult GetReportingColumns()
        {
            return new OkObjectResult(_reportingDataRepository.GetReportingColumns());
        }

        [HttpGet("GetReportingData")]
        public IActionResult GetReportingData()
        {
            var lstMasterViewModel = new List<MasterInformationViewModel>();
            var data = _reportingDataRepository.GetReportingData();
            foreach(var item in data)
            {
                var viewModel = new MasterInformationViewModel();
                viewModel = item;
                viewModel.QuestionAnswer = item.ReportingData.ToDictionary(x => x.Question, y => y.Answer);
                lstMasterViewModel.Add(viewModel);
            }
            return new OkObjectResult(lstMasterViewModel);
        }
        
    }
}