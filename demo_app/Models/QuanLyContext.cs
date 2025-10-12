using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace demo_app.Models;

public partial class QuanLyContext : DbContext
{
    public QuanLyContext()
    {
    }

    public QuanLyContext(DbContextOptions<QuanLyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ban> Bans { get; set; }

    public virtual DbSet<CthoaDon> CthoaDons { get; set; }

    public virtual DbSet<DanhMuc> DanhMucs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<Mon> Mons { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KenG_Kanowaki\\LEMINHDUCSQL;Database=demo;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ban>(entity =>
        {
            entity.HasKey(e => e.MaBan).HasName("PK__Ban__3520ED6C31A30484");

            entity.ToTable("Ban");

            entity.Property(e => e.SoCho).HasDefaultValue(4);
            entity.Property(e => e.TenBan).HasMaxLength(50);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Trống");
        });

        modelBuilder.Entity<CthoaDon>(entity =>
        {
            entity.HasKey(e => e.MaCthd).HasName("PK__CTHoaDon__1E4FA7710EBC1318");

            entity.ToTable("CTHoaDon");

            entity.Property(e => e.MaCthd).HasColumnName("MaCTHD");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Giam)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.Sl).HasColumnName("SL");
            entity.Property(e => e.ThanhTien)
                .HasComputedColumnSql("([SL]*[DonGia]-[Giam])", true)
                .HasColumnType("decimal(30, 2)");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.CthoaDons)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK_CTHoaDon_HoaDon");

            entity.HasOne(d => d.MaMonNavigation).WithMany(p => p.CthoaDons)
                .HasForeignKey(d => d.MaMon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTHoaDon_Mon");
        });

        modelBuilder.Entity<DanhMuc>(entity =>
        {
            entity.HasKey(e => e.MaDm).HasName("PK__DanhMuc__2725866E265B3A05");

            entity.ToTable("DanhMuc");

            entity.Property(e => e.MaDm).HasColumnName("MaDM");
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenDm)
                .HasMaxLength(100)
                .HasColumnName("TenDM");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__2725A6E0D8147435");

            entity.ToTable("HoaDon");

            entity.HasIndex(e => e.SoHd, "UQ__HoaDon__BC3CAB565D5603DE").IsUnique();

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.Giam)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.MaKm).HasColumnName("MaKM");
            entity.Property(e => e.MaNd).HasColumnName("MaND");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.PhiPv)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PhiPV");
            entity.Property(e => e.SoHd)
                .HasMaxLength(50)
                .HasColumnName("SoHD");
            entity.Property(e => e.TamTinh)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Thue)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TongTien)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Mở");

            entity.HasOne(d => d.MaBanNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaBan)
                .HasConstraintName("FK_HoaDon_Ban");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_HoaDon_KhachHang");

            entity.HasOne(d => d.MaKmNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKm)
                .HasConstraintName("FK_HoaDon_KM");

            entity.HasOne(d => d.MaNdNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDon_NguoiDung");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1E992BE589");

            entity.ToTable("KhachHang");

            entity.HasIndex(e => e.Sdt, "UQ__KhachHan__CA1930A57C3DD25F").IsUnique();

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.DiemTl)
                .HasDefaultValue(0)
                .HasColumnName("DiemTL");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.HoTen).HasMaxLength(200);
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
            entity.Property(e => e.ThanhVien).HasDefaultValue(false);
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.MaKm).HasName("PK__KhuyenMa__2725CF150049CF72");

            entity.ToTable("KhuyenMai");

            entity.HasIndex(e => e.MaCode, "UQ__KhuyenMa__152C7C5C43A1D6B0").IsUnique();

            entity.Property(e => e.MaKm).HasColumnName("MaKM");
            entity.Property(e => e.GiamPt)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("GiamPT");
            entity.Property(e => e.GiamTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HoatDong).HasDefaultValue(true);
            entity.Property(e => e.MaCode).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(500);
        });

        modelBuilder.Entity<Mon>(entity =>
        {
            entity.HasKey(e => e.MaMon).HasName("PK__Mon__3A5B29A862831C44");

            entity.ToTable("Mon");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GiaVon).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HoatDong).HasDefaultValue(true);
            entity.Property(e => e.MaDm).HasColumnName("MaDM");
            entity.Property(e => e.TenMon).HasMaxLength(200);

            entity.HasOne(d => d.MaDmNavigation).WithMany(p => p.Mons)
                .HasForeignKey(d => d.MaDm)
                .HasConstraintName("FK_Mon_DanhMuc");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNd).HasName("PK__NguoiDun__2725D72478AD60EC");

            entity.ToTable("NguoiDung");

            entity.HasIndex(e => e.TenDn, "UQ__NguoiDun__4CF96558AC2B0CEF").IsUnique();

            entity.Property(e => e.MaNd).HasColumnName("MaND");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.MaVt).HasColumnName("MaVT");
            entity.Property(e => e.MatKhau).HasMaxLength(256);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.TenDn)
                .HasMaxLength(100)
                .HasColumnName("TenDN");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.NguoiDungs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK_NguoiDung_NhanVien");

            entity.HasOne(d => d.MaVtNavigation).WithMany(p => p.NguoiDungs)
                .HasForeignKey(d => d.MaVt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NguoiDung_VaiTro");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70AE702BB23");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.HoTen).HasMaxLength(200);
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaTt).HasName("PK__ThanhToa__27250079D41C4A29");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.MaTt).HasColumnName("MaTT");
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.HinhThuc).HasMaxLength(50);
            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.NgayTt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("NgayTT");
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThanhToan_HoaDon");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.MaVt).HasName("PK__VaiTro__2725103EDAEEA243");

            entity.ToTable("VaiTro");

            entity.HasIndex(e => e.TenVt, "UQ__VaiTro__4CF9F7BC9CE15E2F").IsUnique();

            entity.Property(e => e.MaVt).HasColumnName("MaVT");
            entity.Property(e => e.TenVt)
                .HasMaxLength(50)
                .HasColumnName("TenVT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
