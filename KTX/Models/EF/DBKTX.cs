namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBKTX : DbContext
    {
        public DBKTX()
            : base("name=DBKTX")
        {
        }

        public virtual DbSet<DIEN> DIENs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<NUOC> NUOCs { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<PHONGSV> PHONGSVs { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DIEN>()
                .Property(e => e.MaDien)
                .IsFixedLength();

            modelBuilder.Entity<DIEN>()
                .Property(e => e.MaPhong)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaHD)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaPhong)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaNV)
                .IsFixedLength();

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MaNV)
                .IsFixedLength();

            modelBuilder.Entity<NUOC>()
                .Property(e => e.MaNuoc)
                .IsFixedLength();

            modelBuilder.Entity<NUOC>()
                .Property(e => e.MaPhong)
                .IsFixedLength();

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MaPhong)
                .IsFixedLength();

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MaCTD)
                .IsFixedLength();

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MaCTN)
                .IsFixedLength();

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.PHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.PHONGSVs)
                .WithRequired(e => e.PHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONGSV>()
                .Property(e => e.MaPhongSV)
                .IsFixedLength();

            modelBuilder.Entity<PHONGSV>()
                .Property(e => e.MaPhong)
                .IsFixedLength();

            modelBuilder.Entity<PHONGSV>()
                .Property(e => e.MaSV)
                .IsFixedLength();

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.MaSV)
                .IsFixedLength();

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.GioiTinh)
                .IsFixedLength();
        }
    }
}
