using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ManagerApartment.Models;

public partial class ManagerApartmentContext : DbContext
{
    public ManagerApartmentContext()
    {
    }

    public ManagerApartmentContext(DbContextOptions<ManagerApartmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddOn> AddOns { get; set; } = null!;

    public virtual DbSet<Apartment> Apartments { get; set; } = null!;

    public virtual DbSet<ApartmentType> ApartmentTypes { get; set; } = null!;

    public virtual DbSet<Asset> Assets { get; set; } = null!;

    public virtual DbSet<AssetHistory> AssetHistories { get; set; } = null!;

    public virtual DbSet<Bill> Bills { get; set; } = null!;

    public virtual DbSet<Building> Buildings { get; set; } = null!;

    public virtual DbSet<Contract> Contracts { get; set; } = null!;

    public virtual DbSet<ContractDetail> ContractDetails { get; set; } = null!;

    public virtual DbSet<Owner> Owners { get; set; } = null!;

    public virtual DbSet<Package> Packages { get; set; } = null!;

    public virtual DbSet<PackageServiceDetail> PackageServiceDetails { get; set; } = null!;

    public virtual DbSet<Request> Requests { get; set; } = null!;

    public virtual DbSet<RequestDetail> RequestDetails { get; set; } = null!;

    public virtual DbSet<RequestLog> RequestLogs { get; set; } = null!;

    public virtual DbSet<Service> Services { get; set; } = null!;

    public virtual DbSet<Staff> Staff { get; set; } = null!;

    public virtual DbSet<StaffDetail> StaffDetails { get; set; } = null!;

    public virtual DbSet<StaffLog> StaffLogs { get; set; } = null!;

    public virtual DbSet<Tennant> Tennants { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //var conn =
        //"";
        //optionsBuilder.UseSqlServer(conn);
        //if (!optionsBuilder.IsConfigured)
        //{
        //    optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database= Manager_Apartment;TrustServerCertificate=True");
        //}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddOn>(entity =>
        {
            entity.HasKey(e => e.AddOnId).HasName("PK__AddOn__682701A4C645370B");

            entity.ToTable("AddOn");

            entity.Property(e => e.AddOnId).HasColumnName("AddOnID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Request).WithMany(p => p.AddOns)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__AddOn__RequestID__6FE99F9F");

            entity.HasOne(d => d.Service).WithMany(p => p.AddOns)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__AddOn__ServiceID__70DDC3D8");
        });

        modelBuilder.Entity<Apartment>(entity =>
        {
            entity.HasKey(e => e.ApartmentId).HasName("PK__Apartmen__CBDF5744EA80DBF6");

            entity.ToTable("Apartment");

            entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");
            entity.Property(e => e.ApartmentStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ApartmentTypeId).HasColumnName("ApartmentTypeID");
            entity.Property(e => e.BuildingId).HasColumnName("BuildingID");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.ToDate).HasColumnType("date");

            entity.HasOne(d => d.ApartmentType).WithMany(p => p.Apartments)
                .HasForeignKey(d => d.ApartmentTypeId)
                .HasConstraintName("FK__Apartment__Apart__403A8C7D");

            entity.HasOne(d => d.Building).WithMany(p => p.Apartments)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK__Apartment__Build__412EB0B6");

            entity.HasOne(d => d.Owner).WithMany(p => p.Apartments)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Apartment__Owner__4222D4EF");
        });

        modelBuilder.Entity<ApartmentType>(entity =>
        {
            entity.HasKey(e => e.ApartmentTypeId).HasName("PK__Apartmen__8BA7C03291493104");

            entity.ToTable("ApartmentType");

            entity.Property(e => e.ApartmentTypeId).HasColumnName("ApartmentTypeID");
            entity.Property(e => e.BuildingId).HasColumnName("BuildingID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Building).WithMany(p => p.ApartmentTypes)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK__Apartment__Build__3D5E1FD2");
        });

        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK__Asset__4349237265B2A50D");

            entity.ToTable("Asset");

            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");
            entity.Property(e => e.AssetHistoryId).HasColumnName("AssetHistoryID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemImage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Apartment).WithMany(p => p.Assets)
                .HasForeignKey(d => d.ApartmentId)
                .HasConstraintName("FK__Asset__Apartment__4E88ABD4");

            entity.HasOne(d => d.AssetHistory).WithMany(p => p.Assets)
                .HasForeignKey(d => d.AssetHistoryId)
                .HasConstraintName("FK__Asset__AssetHist__4D94879B");
        });

        modelBuilder.Entity<AssetHistory>(entity =>
        {
            entity.HasKey(e => e.AssetHistoryId).HasName("PK__AssetHis__5681DDEDE33267A7");

            entity.ToTable("AssetHistory");

            entity.Property(e => e.AssetHistoryId).HasColumnName("AssetHistoryID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemImage)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bill__11F2FC4A06CE2AC5");

            entity.ToTable("Bill");

            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Request).WithMany(p => p.Bills)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__Bill__RequestID__656C112C");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDE4564BE5EA");

            entity.ToTable("Building");

            entity.Property(e => e.BuildingId).HasColumnName("BuildingID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Contract__C90D34095C8941B3");

            entity.ToTable("Contract");

            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");
            entity.Property(e => e.ContractDetailId).HasColumnName("ContractDetailID");
            entity.Property(e => e.ContractImage)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContractStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.ToDate).HasColumnType("date");

            entity.HasOne(d => d.Apartment).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ApartmentId)
                .HasConstraintName("FK__Contract__Apartm__49C3F6B7");

            entity.HasOne(d => d.ContractDetail).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ContractDetailId)
                .HasConstraintName("FK__Contract__Contra__4AB81AF0");
        });

        modelBuilder.Entity<ContractDetail>(entity =>
        {
            entity.HasKey(e => e.ContractDetailId).HasName("PK__Contract__CCA7AF0219FDBE4A");

            entity.ToTable("ContractDetail");

            entity.Property(e => e.ContractDetailId).HasColumnName("ContractDetailID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__Owner__819385989B402EBE");

            entity.ToTable("Owner");

            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PK__Package__322035EC4829DB79");

            entity.ToTable("Package");

            entity.Property(e => e.PackageId).HasColumnName("PackageID");
            entity.Property(e => e.ApartmentTypeId).HasColumnName("ApartmentTypeID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.ApartmentType).WithMany(p => p.Packages)
                .HasForeignKey(d => d.ApartmentTypeId)
                .HasConstraintName("FK__Package__Apartme__534D60F1");
        });

        modelBuilder.Entity<PackageServiceDetail>(entity =>
        {
            entity.HasKey(e => e.PackSerDetailId).HasName("PK__PackageS__EF0F62DB4C1EC5A8");

            entity.ToTable("PackageServiceDetail");

            entity.Property(e => e.PackSerDetailId).HasColumnName("PackSerDetailID");
            entity.Property(e => e.PackageId).HasColumnName("PackageID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Package).WithMany(p => p.PackageServiceDetails)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK__PackageSe__Packa__571DF1D5");

            entity.HasOne(d => d.Service).WithMany(p => p.PackageServiceDetails)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__PackageSe__Servi__5629CD9C");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Request__33A8519A783C169C");

            entity.ToTable("Request");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");
            entity.Property(e => e.BookDateTime).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.ReqStatus)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Apartment).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ApartmentId)
                .HasConstraintName("FK__Request__Apartme__5FB337D6");
        });

        modelBuilder.Entity<RequestDetail>(entity =>
        {
            entity.HasKey(e => e.RequestDetailId).HasName("PK__RequestD__DC528B7058AD6952");

            entity.ToTable("RequestDetail");

            entity.Property(e => e.RequestDetailId).HasColumnName("RequestDetailID");
            entity.Property(e => e.PackageId).HasColumnName("PackageID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");

            entity.HasOne(d => d.Package).WithMany(p => p.RequestDetails)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK__RequestDe__Packa__6D0D32F4");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestDetails)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__RequestDe__Reque__6C190EBB");
        });

        modelBuilder.Entity<RequestLog>(entity =>
        {
            entity.HasKey(e => e.RequestLogId).HasName("PK__RequestL__A2706F5E25904CEC");

            entity.ToTable("RequestLog");

            entity.Property(e => e.RequestLogId).HasColumnName("RequestLogID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaintainItem)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Request).WithMany(p => p.RequestLogs)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__RequestLo__Reque__628FA481");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EA10851A59");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Unit)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF714D24248");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AvatarLink)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StaffStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StaffDetail>(entity =>
        {
            entity.HasKey(e => e.StaffDetailId).HasName("PK__StaffDet__56818E83A25BAA6D");

            entity.ToTable("StaffDetail");

            entity.Property(e => e.StaffDetailId).HasColumnName("StaffDetailID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");

            entity.HasOne(d => d.Service).WithMany(p => p.StaffDetails)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__StaffDeta__Servi__5CD6CB2B");

            entity.HasOne(d => d.Staff).WithMany(p => p.StaffDetails)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__StaffDeta__Staff__5BE2A6F2");
        });

        modelBuilder.Entity<StaffLog>(entity =>
        {
            entity.HasKey(e => e.StaffLogId).HasName("PK__StaffLog__511DAB3CA2BD394C");

            entity.ToTable("StaffLog");

            entity.Property(e => e.StaffLogId).HasColumnName("StaffLogID");
            entity.Property(e => e.RequestLogId).HasColumnName("RequestLogID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");

            entity.HasOne(d => d.RequestLog).WithMany(p => p.StaffLogs)
                .HasForeignKey(d => d.RequestLogId)
                .HasConstraintName("FK__StaffLog__Reques__693CA210");

            entity.HasOne(d => d.Staff).WithMany(p => p.StaffLogs)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__StaffLog__StaffI__68487DD7");
        });

        modelBuilder.Entity<Tennant>(entity =>
        {
            entity.HasKey(e => e.TennantId).HasName("PK__Tennant__901A3DC786213888");

            entity.ToTable("Tennant");

            entity.Property(e => e.TennantId).HasColumnName("TennantID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContractDetailId).HasColumnName("ContractDetailID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ContractDetail).WithMany(p => p.Tennants)
                .HasForeignKey(d => d.ContractDetailId)
                .HasConstraintName("FK__Tennant__Contrac__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
