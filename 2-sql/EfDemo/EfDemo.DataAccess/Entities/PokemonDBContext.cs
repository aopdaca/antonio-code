using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfDemo.DataAccess.Entities
{
    public partial class PokemonDBContext : DbContext
    {
        public PokemonDBContext()
        {
        }

        public PokemonDBContext(DbContextOptions<PokemonDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<EmpDetails> EmpDetails { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Pokemon> Pokemon { get; set; }
        public virtual DbSet<Type> Type { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__Departme__014881AE57A273F4");

                entity.ToTable("Department", "Job");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<EmpDetails>(entity =>
            {
                entity.HasKey(e => e.Edid)
                    .HasName("PK__EmpDetai__27751737E038FEC9");

                entity.ToTable("EmpDetails", "Job");

                entity.HasIndex(e => e.EmpId)
                    .HasName("UQ__EmpDetai__AF2DBB98250EBE26")
                    .IsUnique();

                entity.Property(e => e.Edid)
                    .HasColumnName("EDId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Address2).HasMaxLength(500);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Ed)
                    .WithOne(p => p.EmpDetails)
                    .HasForeignKey<EmpDetails>(d => d.Edid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmpDetails_Employee_EmpId");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBB99DF701D21");

                entity.ToTable("Employee", "Job");

                entity.HasIndex(e => e.Ssn)
                    .HasName("UQ__Employee__CA1E8E3CF5CC0045")
                    .IsUnique();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Ssn).HasColumnName("SSN");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.ToTable("Pokemon", "Poke");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Pokemon__D9C1FA0037019281")
                    .IsUnique();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Evolution)
                    .WithMany(p => p.InverseEvolution)
                    .HasForeignKey(d => d.EvolutionId);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Pokemon)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type", "Poke");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Type__737584F6AFBB2749")
                    .IsUnique();

                entity.Property(e => e.Inital)
                    .HasMaxLength(1)
                    .HasComputedColumnSql("(substring([Name],(1),(1)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
