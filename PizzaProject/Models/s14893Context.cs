using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaProject.Models
{
    public partial class s14893Context : DbContext
    {
        public s14893Context()
        {
        }

        public s14893Context(DbContextOptions<s14893Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Components> Components { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaCafe> PizzaCafe { get; set; }
        public virtual DbSet<PizzaComponent> PizzaComponent { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserCafe> UserCafe { get; set; }
        public virtual DbSet<UserOpportunities> UserOpportunities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s14893;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Components>(entity =>
            {
                entity.HasKey(e => e.IdComponent)
                    .HasName("Components_pk");

                entity.Property(e => e.IdComponent).ValueGeneratedNever();

                entity.Property(e => e.NameComponent)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("Orders_pk");

                entity.Property(e => e.IdOrder).ValueGeneratedNever();

                entity.Property(e => e.Lokalizacja)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameOrder)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Promocje)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusOrder)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza).ValueGeneratedNever();

                entity.Property(e => e.NamePizza)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_IdOrder");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Order");
            });

            modelBuilder.Entity<PizzaCafe>(entity =>
            {
                entity.HasKey(e => e.IdPizzaCafe)
                    .HasName("PizzaCafe_pk");

                entity.Property(e => e.IdPizzaCafe).ValueGeneratedNever();

                entity.Property(e => e.NameCafe)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumerKonta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaComponent>(entity =>
            {
                entity.HasKey(e => new { e.ComponentsIdComponent, e.PizzaIdPizza })
                    .HasName("PizzaComponent_pk");

                entity.Property(e => e.ComponentsIdComponent).HasColumnName("Components_IdComponent");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_IdPizza");

                entity.HasOne(d => d.ComponentsIdComponentNavigation)
                    .WithMany(p => p.PizzaComponent)
                    .HasForeignKey(d => d.ComponentsIdComponent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_11_Components");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PizzaComponent)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_11_Pizza");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("Roles_pk");

                entity.Property(e => e.IdRole).ValueGeneratedNever();

                entity.Property(e => e.NameRole)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserIdUser).HasColumnName("User_IdUser");

                entity.HasOne(d => d.UserIdUserNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.UserIdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Roles_User");
            });

            modelBuilder.Entity<UserCafe>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("UserCafe_pk");

                entity.Property(e => e.IdUser).ValueGeneratedNever();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaCafeIdPizzaCafe).HasColumnName("PizzaCafe_IdPizzaCafe");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PizzaCafeIdPizzaCafeNavigation)
                    .WithMany(p => p.UserCafe)
                    .HasForeignKey(d => d.PizzaCafeIdPizzaCafe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_PizzaCafe");
            });

            modelBuilder.Entity<UserOpportunities>(entity =>
            {
                entity.HasKey(e => new { e.UserIdUser, e.PizzaCafeIdPizzaCafe, e.OrderIdOrder })
                    .HasName("UserOpportunities_pk");

                entity.Property(e => e.UserIdUser).HasColumnName("User_IdUser");

                entity.Property(e => e.PizzaCafeIdPizzaCafe).HasColumnName("PizzaCafe_IdPizzaCafe");

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_IdOrder");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.UserOpportunities)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserOpportunities_Order");

                entity.HasOne(d => d.PizzaCafeIdPizzaCafeNavigation)
                    .WithMany(p => p.UserOpportunities)
                    .HasForeignKey(d => d.PizzaCafeIdPizzaCafe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserOpportunities_PizzaCafe");

                entity.HasOne(d => d.UserIdUserNavigation)
                    .WithMany(p => p.UserOpportunities)
                    .HasForeignKey(d => d.UserIdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserOpportunities_User");
            });
        }
    }
}
