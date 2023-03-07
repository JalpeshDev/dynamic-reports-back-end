using System;
using System.Collections.Generic;

namespace DynamicReportWebApi.Models;

public partial class MasterInformation
{
    public int OrganizationId { get; set; }

    public string OrganizationName { get; set; } = null!;

    public int? TaxId { get; set; }

    public string PrimaryContact { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<ReportingDatum> ReportingData { get; } = new List<ReportingDatum>();
}
