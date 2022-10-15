using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProiectAfaceriElectronice.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comenzi> Comenzis { get; set; }
        public virtual DbSet<Detaliicomenzi> Detaliicomenzis { get; set; }
        public virtual DbSet<Feedbackproduse> Feedbackproduses { get; set; }
        public virtual DbSet<Produse> Produses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=afaceri1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack");

            modelBuilder.Entity<Comenzi>(entity =>
            {
                entity.HasKey(e => e.Idcomanda)
                    .HasName("comenzi_pkey");

                entity.ToTable("comenzi");

                entity.Property(e => e.Idcomanda)
                    .HasColumnName("idcomanda")
                    .HasDefaultValueSql("nextval('com_seq'::regclass)");

                entity.Property(e => e.Datacomanda).HasColumnName("datacomanda");

                entity.Property(e => e.Datalivrare).HasColumnName("datalivrare");
            });

            modelBuilder.Entity<Detaliicomenzi>(entity =>
            {
                entity.HasKey(e => new { e.Idcomanda, e.Idprodus })
                    .HasName("pk_detaliicomenzi");

                entity.ToTable("detaliicomenzi");

                entity.Property(e => e.Idcomanda).HasColumnName("idcomanda");

                entity.Property(e => e.Idprodus).HasColumnName("idprodus");

                entity.Property(e => e.Adresalivrare)
                    .HasMaxLength(50)
                    .HasColumnName("adresalivrare")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Cantitate).HasColumnName("cantitate");

                entity.Property(e => e.Numeutilizator)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("numeutilizator");

                entity.Property(e => e.Pret).HasColumnName("pret");

                entity.HasOne(d => d.IdcomandaNavigation)
                    .WithMany(p => p.Detaliicomenzis)
                    .HasForeignKey(d => d.Idcomanda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idcomanda");

                entity.HasOne(d => d.IdprodusNavigation)
                    .WithMany(p => p.Detaliicomenzis)
                    .HasForeignKey(d => d.Idprodus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idprodus");
            });

            modelBuilder.Entity<Feedbackproduse>(entity =>
            {
                entity.HasKey(e => e.Idfeedback)
                    .HasName("feedbackproduse_pkey");

                entity.ToTable("feedbackproduse");

                entity.Property(e => e.Idfeedback)
                    .HasColumnName("idfeedback")
                    .HasDefaultValueSql("nextval('feed_seq'::regclass)");

                entity.Property(e => e.Client)
                    .HasMaxLength(50)
                    .HasColumnName("client")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Dataadaugare).HasColumnName("dataadaugare");

                entity.Property(e => e.Descriere)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descriere");

                entity.Property(e => e.Idprodus).HasColumnName("idprodus");

                entity.Property(e => e.Pozeprodus)
                    .HasMaxLength(50)
                    .HasColumnName("pozeprodus")
                    .HasDefaultValueSql("NULL::character varying");

                entity.HasOne(d => d.IdprodusNavigation)
                    .WithMany(p => p.Feedbackproduses)
                    .HasForeignKey(d => d.Idprodus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_feedback");
            });

            modelBuilder.Entity<Produse>(entity =>
            {
                entity.HasKey(e => e.Idprodus)
                    .HasName("produse_pkey");

                entity.ToTable("produse");

                entity.Property(e => e.Idprodus)
                    .HasColumnName("idprodus")
                    .HasDefaultValueSql("nextval('prod_seq'::regclass)");

                entity.Property(e => e.Brandcompatibil)
                    .HasMaxLength(40)
                    .HasColumnName("brandcompatibil")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Capacitatestoc)
                    .HasColumnName("capacitatestoc")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Codprodus).HasColumnName("codprodus");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("denumire");

                entity.Property(e => e.Furnizor)
                    .HasMaxLength(50)
                    .HasColumnName("furnizor")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Poze)
                    .HasMaxLength(50)
                    .HasColumnName("poze")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Pret)
                    .HasColumnName("pret")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.HasSequence("com_seq");

            modelBuilder.HasSequence("feed_seq");

            modelBuilder.HasSequence("prod_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
