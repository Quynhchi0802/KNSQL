using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KNSQL.Models
{
    public partial class LapTrinhQuanLyDBContext : DbContext
    {
        public LapTrinhQuanLyDBContext()
            : base("name=LapTrinhQuanLyDBContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<NewPerson> NewPersons { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Nguoi> Nguois { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }






        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
