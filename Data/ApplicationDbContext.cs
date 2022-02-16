using BilliWebApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BilliWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }

        public DbSet<MotorcycleImage> MotorcycleImages { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartContent> CartContents { get; set; }


        public async Task<bool> SaveAsync()
        {
            var changesNumber = await SaveChangesAsync();

            return changesNumber != 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MotorcycleImage>()
                .HasOne(mi => mi.Motorcycle)
                .WithOne(m => m.Image).HasForeignKey<MotorcycleImage>(mi => new { mi.ID })
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasKey(x => new { x.CartID, x.UserID });

            modelBuilder.Entity<Cart>()
                .HasMany(x => x.CartContents)
                .WithOne(x => x.Cart);

            modelBuilder.Entity<CartContent>()
                .HasKey(x => new { x.CartID, x.MotorcycleID });

            modelBuilder.Entity<CartContent>()
                .HasOne(x => x.Cart)
                .WithMany(x => x.CartContents);
        }
    }
}
