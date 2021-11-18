using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SQLDAL.Models;
using System;
using System.Collections.Generic;

namespace SQLDAL
{
    public class EFCoreContext : DbContext
    {
        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Good> Goods { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<GoodsWarehouse> GoodsWarehouses { get; set; }

        public DbSet<GoodCount> TotalGoodsCount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<GoodCount>()
                .ToView("TotalGoodCount")
                .HasKey(x => x.Id);

            modelBuilder.Entity<GoodsWarehouse>()
                .HasKey(x => new { x.GoodId, x.WarehouseId });

            modelBuilder.Entity<GoodsWarehouse>()
                .HasOne(goodsWarehouses => goodsWarehouses.Good)
                .WithMany(good => good.GoodsWarehouses)
                .HasForeignKey(goodsWarehouses => goodsWarehouses.GoodId);

            modelBuilder.Entity<GoodsWarehouse>()
                .HasOne(goodsWarehouses => goodsWarehouses.Warehouse)
                .WithMany(warehouse => warehouse.GoodsWarehouses)
                .HasForeignKey(goodsWarehouses => goodsWarehouses.WarehouseId);

            List<Good> goods = new List<Good>
            {
                new Good{ Id = Guid.NewGuid(), Title = "GoodA" },
                new Good{ Id = Guid.NewGuid(), Title = "GoodB" },
                new Good{ Id = Guid.NewGuid(), Title = "GoodC" }
            };
            modelBuilder.Entity<Good>().
                HasData(goods);

            var warehouses = new List<Warehouse>
            {
                new Warehouse{ Id = Guid.NewGuid(), Address = "AddressA" },
                new Warehouse{ Id = Guid.NewGuid(), Address = "AddressB" },
                new Warehouse{ Id = Guid.NewGuid(), Address = "AddressC" }
            };
            modelBuilder.Entity<Warehouse>().
                HasData(warehouses);

            var goodsWarehouses = new List<GoodsWarehouse>
            {
                new GoodsWarehouse
                {
                    GoodId = goods[0].Id,
                    WarehouseId = warehouses[0].Id,
                    Count = 5
                },
                new GoodsWarehouse
                {
                    GoodId = goods[0].Id,
                    WarehouseId = warehouses[1].Id,
                    Count = 3
                },
                new GoodsWarehouse
                {
                    GoodId = goods[0].Id,
                    WarehouseId = warehouses[2].Id,
                    Count = 4
                },
                new GoodsWarehouse
                {
                    GoodId = goods[1].Id,
                    WarehouseId = warehouses[0].Id,
                    Count = 10
                },
                new GoodsWarehouse
                {
                    GoodId = goods[1].Id,
                    WarehouseId = warehouses[2].Id,
                    Count = 8
                },
                new GoodsWarehouse
                {
                    GoodId = goods[2].Id,
                    WarehouseId = warehouses[0].Id,
                    Count = 1
                },
                new GoodsWarehouse
                {
                    GoodId = goods[2].Id,
                    WarehouseId = warehouses[1].Id,
                    Count = 2
                },
            };
            modelBuilder.Entity<GoodsWarehouse>().
                HasData(goodsWarehouses);
        }
    }
}
