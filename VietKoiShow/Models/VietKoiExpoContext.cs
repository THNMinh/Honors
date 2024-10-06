using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VietKoiShow.Models;

public partial class VietKoiExpoContext : DbContext
{
    public VietKoiExpoContext()
    {
    }

    public VietKoiExpoContext(DbContextOptions<VietKoiExpoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblcategory> Tblcategories { get; set; }

    public virtual DbSet<Tblcompetition> Tblcompetitions { get; set; }

    public virtual DbSet<TblkoiFish> TblkoiFishes { get; set; }

    public virtual DbSet<Tblnews> Tblnews { get; set; }

    public virtual DbSet<TblnewsType> TblnewsTypes { get; set; }

    public virtual DbSet<Tblprediction> Tblpredictions { get; set; }

    public virtual DbSet<Tblregistration> Tblregistrations { get; set; }

    public virtual DbSet<Tblresult> Tblresults { get; set; }

    public virtual DbSet<Tblrole> Tblroles { get; set; }

    public virtual DbSet<Tblscore> Tblscores { get; set; }

    public virtual DbSet<Tbluser> Tblusers { get; set; }

    public virtual DbSet<Tblvariety> Tblvarieties { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source = .\\MSSQL2022EXPRESS; Initial Catalog = VietKoiExpo; Persist Security Info=True; User ID = sa; Password = 12345; Encrypt = False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tblcategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__TBLCateg__19093A2B870AE3D6");

            entity.ToTable("TBLCategory");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Category_Description");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Species)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tblcompetition>(entity =>
        {
            entity.HasKey(e => e.CompId).HasName("PK__TBLCompe__AD362A76AD2BEC90");

            entity.ToTable("TBLCompetition");

            entity.Property(e => e.CompId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CompID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CategoryID");
            entity.Property(e => e.CompDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Tblcompetitions)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_TBLCompetition_CategoryID");
        });

        modelBuilder.Entity<TblkoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__TBLKoiFi__E03435B85376C1B9");

            entity.ToTable("TBLKoiFish");

            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KoiID");
            entity.Property(e => e.KoiName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ResultId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ResultID");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.VarietyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VarietyID");

            entity.HasOne(d => d.Result).WithMany(p => p.TblkoiFishes)
                .HasForeignKey(d => d.ResultId)
                .HasConstraintName("FK_TBLKoiFish_ResultID");

            entity.HasOne(d => d.User).WithMany(p => p.TblkoiFishes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TBLKoiFis__UserI__44FF419A");

            entity.HasOne(d => d.Variety).WithMany(p => p.TblkoiFishes)
                .HasForeignKey(d => d.VarietyId)
                .HasConstraintName("FK__TBLKoiFis__Varie__440B1D61");
        });

        modelBuilder.Entity<Tblnews>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__TBLNews__954EBDD323D8C63D");

            entity.ToTable("TBLNews");

            entity.Property(e => e.NewsId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NewsID");
            entity.Property(e => e.NewsTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NewsTypeID");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.NewsType).WithMany(p => p.Tblnews)
                .HasForeignKey(d => d.NewsTypeId)
                .HasConstraintName("FK__TBLNews__NewsTyp__3E52440B");

            entity.HasOne(d => d.User).WithMany(p => p.Tblnews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TBLNews__UserID__3F466844");
        });

        modelBuilder.Entity<TblnewsType>(entity =>
        {
            entity.HasKey(e => e.NewsTypeId).HasName("PK__TBLNewsT__9013FE2A5CA3A75C");

            entity.ToTable("TBLNewsType");

            entity.Property(e => e.NewsTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NewsTypeID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tblprediction>(entity =>
        {
            entity.HasKey(e => e.PredictionId).HasName("PK__TBLPredi__BAE4C140C86C7AA4");

            entity.ToTable("TBLPrediction");

            entity.Property(e => e.PredictionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PredictionID");
            entity.Property(e => e.CompId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CompID");
            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KoiID");

            entity.HasOne(d => d.Comp).WithMany(p => p.Tblpredictions)
                .HasForeignKey(d => d.CompId)
                .HasConstraintName("FK__TBLPredic__CompI__5535A963");

            entity.HasOne(d => d.Koi).WithMany(p => p.Tblpredictions)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__TBLPredic__KoiID__5441852A");
        });

        modelBuilder.Entity<Tblregistration>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__TBLRegis__6EF58830FFE247A1");

            entity.ToTable("TBLRegistration");

            entity.Property(e => e.RegistrationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RegistrationID");
            entity.Property(e => e.CompId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CompID");
            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KoiID");

            entity.HasOne(d => d.Comp).WithMany(p => p.Tblregistrations)
                .HasForeignKey(d => d.CompId)
                .HasConstraintName("FK__TBLRegist__CompI__4E88ABD4");

            entity.HasOne(d => d.Koi).WithMany(p => p.Tblregistrations)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__TBLRegist__KoiID__4D94879B");
        });

        modelBuilder.Entity<Tblresult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__TBLResul__97690228895F78EA");

            entity.ToTable("TBLResult");

            entity.Property(e => e.ResultId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ResultID");
            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KoiID");
            entity.Property(e => e.Prize)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Koi).WithMany(p => p.Tblresults)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__TBLResult__KoiID__47DBAE45");
        });

        modelBuilder.Entity<Tblrole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__TBLRole__8AFACE3AE8126C23");

            entity.ToTable("TBLRole");

            entity.Property(e => e.RoleId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Role_Description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tblscore>(entity =>
        {
            entity.HasKey(e => e.ScoreId).HasName("PK__TBLScore__7DD229F13E5E5D99");

            entity.ToTable("TBLScore");

            entity.Property(e => e.ScoreId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ScoreID");
            entity.Property(e => e.CompId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CompID");
            entity.Property(e => e.KoiId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KoiID");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Comp).WithMany(p => p.Tblscores)
                .HasForeignKey(d => d.CompId)
                .HasConstraintName("FK__TBLScore__CompID__59063A47");

            entity.HasOne(d => d.Koi).WithMany(p => p.Tblscores)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__TBLScore__KoiID__5812160E");

            entity.HasOne(d => d.User).WithMany(p => p.Tblscores)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TBLScore__UserID__59FA5E80");
        });

        modelBuilder.Entity<Tbluser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__TBLUser__1788CCACE01F8A26");

            entity.ToTable("TBLUser");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoleId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Tblusers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__TBLUser__RoleID__3B75D760");
        });

        modelBuilder.Entity<Tblvariety>(entity =>
        {
            entity.HasKey(e => e.VarietyId).HasName("PK__TBLVarie__08E3A048C6F34A8B");

            entity.ToTable("TBLVariety");

            entity.Property(e => e.VarietyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VarietyID");
            entity.Property(e => e.Origin)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VarietyDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Variety_Description");
            entity.Property(e => e.VarietyName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
