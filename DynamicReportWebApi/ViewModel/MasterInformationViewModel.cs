namespace DynamicReportWebApi.ViewModel
{
    public class MasterInformationViewModel
    {
        public MasterInformationViewModel()
        {
            ReportingData = new List<ReportingDataViewModel>();
        }
        public int OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public int? TaxId { get; set; }

        public string PrimaryContact { get; set; }

        public Dictionary<string,string> QuestionAnswer { get; set; }

        public DateTime CreatedOn { get; set; }

        public  List<ReportingDataViewModel> ReportingData { get; set; }
    }
}
