using FishingMania.Data.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FishingMania.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ApplicationUserFishingPlace> ApplicationUsersFishingPlaces { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;

        public virtual DbSet<Event> Events { get; set; } = null!;

        public virtual DbSet<FishingPlace> FishingPlaces { get; set; } = null!;
        public virtual DbSet<TypesFishing> TypesFishings { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserFishingPlace>()
                .HasKey(fp => new { fp.ApplicationUserId, fp.FishingPlaceId });
            builder.Entity<FishingPlace>()
                .HasOne(g => g.User)
                .WithMany()
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ApplicationUserFishingPlace>()
                .HasOne(g => g.ApplicationUser)
                .WithMany()
                .HasForeignKey(g => g.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<TypesFishing>()
                .HasData(
                new TypesFishing { Id = new Guid("12C8DD8d-346B-426E-B06C-75BBA97DCD63"), Name = "RiverFishing" },
                new TypesFishing { Id = new Guid("bc64e8ef-5f7c-4edc-83d5-a43c9973eefc"), Name = "LakeFishing" },
                new TypesFishing { Id = new Guid("bd719745-fa48-4adc-bac1-0898a04e5822"), Name = "SeaFishing" });


        }
    }
}
