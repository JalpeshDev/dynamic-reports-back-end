using System;
using System.Collections.Generic;

namespace DynamicReportWebApi.Models;

public partial class ReportingDatum
{
    public int Id { get; set; }

    public int OrganizationId { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public virtual MasterInformation Organization { get; set; } = null!;
}
