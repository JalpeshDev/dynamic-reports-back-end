using DynamicReportWebApi.ViewModel;

namespace DynamicReport.InterfaceRepository
{
    public interface IReportingDataRepository
    {
        IEnumerable<string> GetReportingColumns();

        IEnumerable<MasterInformationViewModel> GetReportingData();
    }
}