using System;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL
{
    public partial class PriceTrackerContext : DbContext
    {
        public PriceTrackerContext()
        {
        }

        public PriceTrackerContext(DbContextOptions<PriceTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Companyproduct> Companyproducts { get; set; }
        public virtual DbSet<Costumer> Costumers { get; set; }
        public virtual DbSet<Costumerproduct> Costumerproducts { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Producttoadvertise> Producttoadvertises { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=PriceTracker;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Companylink)
                    .IsRequired()
                    .HasColumnName("companylink");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Packageid).HasColumnName("packageid");

                entity.Property(e => e.Passward)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("passward");

                entity.Property(e => e.Startofsubsciption)
                    .HasColumnType("date")
                    .HasColumnName("startofsubsciption");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.Packageid)
                    .HasConstraintName("FK_company_package");
            });

            modelBuilder.Entity<Companyproduct>(entity =>
            {
                entity.ToTable("companyproducts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Productlink)
                    .IsRequired()
                    .HasColumnName("productlink");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Companyproducts)
                    .HasForeignKey(d => d.Companyid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_companyproducts_company");
            });

            modelBuilder.Entity<Costumer>(entity =>
            {
                entity.ToTable("costumer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("password")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Costumerproduct>(entity =>
            {
                entity.ToTable("costumerproduct");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Baseprice).HasColumnName("baseprice");

                entity.Property(e => e.Costumerid).HasColumnName("costumerid");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Finalprice).HasColumnName("finalprice");

                entity.Property(e => e.Productlink)
                    .IsRequired()
                    .HasColumnName("productlink");

                entity.HasOne(d => d.Costumer)
                    .WithMany(p => p.Costumerproducts)
                    .HasForeignKey(d => d.Costumerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_costumerproduct_costumer");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("package");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Productsamount).HasColumnName("productsamount");
            });

            modelBuilder.Entity<Producttoadvertise>(entity =>
            {
                entity.ToTable("producttoadvertise");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Companyproductid).HasColumnName("companyproductid");

                entity.Property(e => e.Costumerproductid).HasColumnName("costumerproductid");

                entity.HasOne(d => d.Companyproduct)
                    .WithMany(p => p.Producttoadvertises)
                    .HasForeignKey(d => d.Companyproductid)
                    .HasConstraintName("FK_producttoadvertise_companyproducts");

                entity.HasOne(d => d.Costumerproduct)
                    .WithMany(p => p.Producttoadvertises)
                    .HasForeignKey(d => d.Costumerproductid)
                    .HasConstraintName("FK_producttoadvertise_costumerproduct");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasMaxLength(50)
                    .HasColumnName("HOST");

                entity.Property(e => e.Method)
                    .HasMaxLength(10)
                    .HasColumnName("METHOD")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .HasColumnName("PATH");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.Referer)
                    .HasMaxLength(100)
                    .HasColumnName("REFERER");

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
