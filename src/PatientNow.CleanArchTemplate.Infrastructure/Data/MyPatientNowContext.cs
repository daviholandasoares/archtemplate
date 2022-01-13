using Microsoft.EntityFrameworkCore;
using PatientNow.CleanArchTemplate.Core.Models;

//This class was created automatically through by Dotnet EF Tool(Scaffold).
namespace PatientNow.CleanArchTemplate.Infrastructure.Data;

public partial class MyPatientNowContext : DbContext
{
    public MyPatientNowContext()
    {
    }

    public MyPatientNowContext(DbContextOptions<MyPatientNowContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PatientBasicInfo> PatientBasicInfos { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<PatientBasicInfo>(entity =>
        {
            entity.HasKey(e => e.PatientId);

            entity.ToTable("PatientBasicInfo");

            entity.Property(e => e.Church)
                .HasMaxLength(50)
                .HasColumnName("church");

            entity.Property(e => e.Cotherproviderid).HasColumnName("cotherproviderid");

            entity.Property(e => e.Cprimaryproviderid).HasColumnName("cprimaryproviderid");

            entity.Property(e => e.DoNotRequireEmailAuthenticationDateTime).HasColumnType("datetime");

            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");

            entity.Property(e => e.EthnicId).HasColumnName("ethnicId");

            entity.Property(e => e.Ethnicity).HasMaxLength(50);

            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("FName");

            entity.Property(e => e.FormerName).HasMaxLength(50);

            entity.Property(e => e.Gender).HasMaxLength(1);

            entity.Property(e => e.Hasprimarycareprovider)
                .HasColumnName("hasprimarycareprovider")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.Isprimarycareprovider)
                .HasColumnName("isprimarycareprovider")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .HasColumnName("language");

            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("LName");

            entity.Property(e => e.Marital).HasMaxLength(50);

            entity.Property(e => e.Mname)
                .HasMaxLength(50)
                .HasColumnName("MName");

            entity.Property(e => e.NickName).HasMaxLength(50);

            entity.Property(e => e.PatientNowId).HasColumnName("PatientNowID");

            entity.Property(e => e.Pharmacy).HasMaxLength(50);

            entity.Property(e => e.PracticeId).HasColumnName("PracticeID");

            entity.Property(e => e.PrimaryCareProvider).HasMaxLength(50);

            entity.Property(e => e.Race).HasMaxLength(50);

            entity.Property(e => e.ReferralDetail).HasMaxLength(50);

            entity.Property(e => e.ReferralSource).HasMaxLength(50);

            entity.Property(e => e.ReferringProvider).HasMaxLength(50);

            entity.Property(e => e.Refsourcedetail)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("refsourcedetail")
                .HasDefaultValueSql("('')");

            entity.Property(e => e.Refsourceid).HasColumnName("refsourceid");

            entity.Property(e => e.Refsourceobjid).HasColumnName("refsourceobjid");

            entity.Property(e => e.Religion)
                .HasMaxLength(50)
                .HasColumnName("religion");

            entity.Property(e => e.Specifichealthcareprovider)
                .HasColumnName("specifichealthcareprovider")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.Ssn)
                .HasMaxLength(12)
                .HasColumnName("SSN");

            entity.Property(e => e.Title).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}