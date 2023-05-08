using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScaffoldDatabase.Models
{
    public partial class CanteenDBContext : DbContext
    {
        public CanteenDBContext()
        {
        }

        public CanteenDBContext(DbContextOptions<CanteenDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FoodMapping> FoodMappings { get; set; } = null!;
        public virtual DbSet<FoodMenu> FoodMenus { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<KitchenFood> KitchenFoods { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<Supply> Supplies { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-D20GNE0\\SQLEXPRESS;Database=CanteenDB;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodMapping>(entity =>
            {
                entity.HasKey(e => e.MappingId);

                entity.ToTable("FoodMapping");

                entity.HasIndex(e => e.FoodId, "IX_FoodMapping_FoodID");

                entity.HasIndex(e => e.ItemId, "IX_FoodMapping_ItemId");

                entity.Property(e => e.MappingId).HasColumnName("MappingID");

                entity.Property(e => e.FoodId).HasColumnName("FoodID");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.FoodMappings)
                    .HasForeignKey(d => d.FoodId);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.FoodMappings)
                    .HasForeignKey(d => d.ItemId);
            });

            modelBuilder.Entity<FoodMenu>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.ToTable("FoodMenu");

                entity.Property(e => e.FoodId).HasColumnName("FoodID");

                entity.Property(e => e.FoodName).HasMaxLength(200);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemCode);

                entity.ToTable("Item");

                entity.HasIndex(e => e.UnitId, "IX_Item_UnitId");

                entity.Property(e => e.ItemName).HasMaxLength(300);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.UnitId);
            });

            modelBuilder.Entity<KitchenFood>(entity =>
            {
                entity.ToTable("KitchenFood");

                entity.HasIndex(e => e.FoodId, "IX_KitchenFood_FoodID")
                    .IsUnique()
                    .HasFilter("([FoodID] IS NOT NULL)");

                entity.Property(e => e.KitchenFoodId).HasColumnName("KitchenFoodID");

                entity.Property(e => e.FoodId).HasColumnName("FoodID");

                entity.HasOne(d => d.Food)
                    .WithOne(p => p.KitchenFood)
                    .HasForeignKey<KitchenFood>(d => d.FoodId);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.PurchaseNo);

                entity.ToTable("Purchase");

                entity.HasIndex(e => e.ItemId, "IX_Purchase_ItemId");

                entity.HasIndex(e => e.SupplyId, "IX_Purchase_SupplyId");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.ItemId);

                entity.HasOne(d => d.Supply)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.SupplyId);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.SalesId);

                entity.HasIndex(e => e.KitchenFoodId, "IX_Sales_KitchenFoodID");

                entity.Property(e => e.SalesId).HasColumnName("SalesID");

                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.KitchenFoodId).HasColumnName("KitchenFoodID");

                entity.Property(e => e.Upi).HasColumnName("UPI");

                entity.HasOne(d => d.KitchenFood)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.KitchenFoodId);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("Stock");

                entity.HasIndex(e => e.ItemId, "IX_Stock_ItemId")
                    .IsUnique()
                    .HasFilter("([ItemId] IS NOT NULL)");

                entity.Property(e => e.StockId).HasColumnName("StockID");

                entity.HasOne(d => d.Item)
                    .WithOne(p => p.Stock)
                    .HasForeignKey<Stock>(d => d.ItemId);
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.ToTable("Supply");

                entity.Property(e => e.SupplyId).HasColumnName("SupplyID");

                entity.Property(e => e.SupplierName).HasMaxLength(300);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UnitName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
