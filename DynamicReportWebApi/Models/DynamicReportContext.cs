using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DynamicReportWebApi.Models;

public partial class DynamicReportContext : DbContext
{
    public DynamicReportContext()
    {
    }

    public DynamicReportContext(DbContextOptions<DynamicReportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MasterInformation> MasterInformations { get; set; }

    public virtual DbSet<ReportingDatum> ReportingData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-R92EE3A\\SQLSERVER;Initial Catalog=dynamicReport;Integrated Security=True;User ID=sa;Password=shaili@123;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MasterInformation>(entity =>
        {
            entity.HasKey(e => e.OrganizationId);

            entity.ToTable("MasterInformation");
        });

        modelBuilder.Entity<ReportingDatum>(entity =>
        {
            entity.HasOne(d => d.Organization).WithMany(p => p.ReportingData)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReportingData_MasterInformation");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
