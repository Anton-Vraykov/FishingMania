using FishingMania.Data.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FishingMania.Data
{
    public class ApplicationDbContext : IdentityDbContext
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


        }
    }
}
