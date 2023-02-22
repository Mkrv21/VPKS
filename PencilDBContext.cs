using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PencilApp
{
    public partial class PencilDBContext : DbContext
    {
        private static PencilDBContext _context;
        public PencilDBContext()
        {
        }

        public PencilDBContext(DbContextOptions<PencilDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductsInOrder> ProductsInOrders { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        public static PencilDBContext GetContext()
        {
            if (_context == null)
            {
                _context = new PencilDBContext();

            }
            return _context;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\Оксана\\Desktop\\PencilApp\\PencilDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrders);

                entity.HasIndex(e => e.IdOrders, "IX_Orders_id_Orders")
                    .IsUnique();

                entity.Property(e => e.IdOrders).HasColumnName("id_Orders");

                entity.Property(e => e.Adress).HasColumnName("adress");

                entity.Property(e => e.CostOrders).HasColumnName("cost_Orders");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IdUsers).HasColumnName("id_Users");

                entity.Property(e => e.Payment).HasColumnName("payment");

                entity.HasOne(d => d.IdUsersNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdUsers)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProducts);

                entity.HasIndex(e => e.IdProducts, "IX_Products_id_Products")
                    .IsUnique();

                entity.Property(e => e.IdProducts).HasColumnName("id_Products");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<ProductsInOrder>(entity =>
            {
                entity.HasKey(e => e.IdProductsInOrders);

                entity.HasIndex(e => e.IdProductsInOrders, "IX_ProductsInOrders_id_ProductsInOrders")
                    .IsUnique();

                entity.Property(e => e.IdProductsInOrders).HasColumnName("id_ProductsInOrders");

                entity.Property(e => e.IdOrders).HasColumnName("id_Orders");

                entity.Property(e => e.IdProducts).HasColumnName("id_Products");

                entity.HasOne(d => d.IdOrdersNavigation)
                    .WithMany(p => p.ProductsInOrders)
                    .HasForeignKey(d => d.IdOrders)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdProductsNavigation)
                    .WithMany(p => p.ProductsInOrders)
                    .HasForeignKey(d => d.IdProducts)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUsers);

                entity.HasIndex(e => e.IdUsers, "IX_Users_id_Users")
                    .IsUnique();

                entity.HasIndex(e => e.Login, "IX_Users_login")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "IX_Users_phone")
                    .IsUnique();

                entity.Property(e => e.IdUsers).HasColumnName("id_Users");

                entity.Property(e => e.Login).HasColumnName("login");

                entity.Property(e => e.Pass).HasColumnName("pass");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
