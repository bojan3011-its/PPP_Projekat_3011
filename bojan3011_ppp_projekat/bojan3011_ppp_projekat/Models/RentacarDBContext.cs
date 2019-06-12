namespace bojan3011_ppp_projekat.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RentacarDBContext : DbContext
    {
        public RentacarDBContext()
            : base("name=RentacarDBContext")
        {
        }

        public virtual DbSet<Drzava> Drzavas { get; set; }
        public virtual DbSet<KategorijaVozila> KategorijaVozilas { get; set; }
        public virtual DbSet<Klijent> Klijents { get; set; }
        public virtual DbSet<Nalog> Nalogs { get; set; }
        public virtual DbSet<Proizvodjac> Proizvodjacs { get; set; }
        public virtual DbSet<Vozilo> Voziloes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>()
                .HasMany(e => e.Klijents)
                .WithRequired(e => e.Drzava)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Drzava>()
                .HasMany(e => e.Proizvodjacs)
                .WithRequired(e => e.Drzava)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KategorijaVozila>()
                .Property(e => e.Oznaka)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KategorijaVozila>()
                .HasMany(e => e.Voziloes)
                .WithRequired(e => e.KategorijaVozila)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klijent>()
                .HasMany(e => e.Nalogs)
                .WithRequired(e => e.Klijent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nalog>()
                .Property(e => e.MozeInostranstvo)
                .IsFixedLength();

            modelBuilder.Entity<Nalog>()
                .Property(e => e.VracaUInostranstvu)
                .IsFixedLength();

            modelBuilder.Entity<Proizvodjac>()
                .HasMany(e => e.Voziloes)
                .WithRequired(e => e.Proizvodjac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vozilo>()
                .HasMany(e => e.Nalogs)
                .WithRequired(e => e.Vozilo)
                .WillCascadeOnDelete(false);
        }
    }
}
