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

            builder
               .Entity<FishingPlace>()
               .HasData(
               new FishingPlace
               {
                   Id = new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16"),
                   Name = "Studen kladenets",
                   PictureURL = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/467694130.jpg?k=694e5ed2ad33b65f2e3d3c34e5016b7d853416e0b8502bd5569db2d32c4fb8e5&o=",
                   Location = "Studen kladenets",
                   Description = "Studen kladenets (Cold well) is a reservoir in Eastern Rhodope Mountains, built on Arda river. It is part of a huge Communist project, implemented in the 1960-s, when many rivers in Bulgaria were damed, the flow of water obstructed with few villages stayed under water. The Arda project involves three big reservoirs and it is announced “Arda Cascade”.  Studen kladenets is in the middle.The rezervation for fishing in this place is 3 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********",
                   UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                   TypeFishingId = new Guid("bc64e8ef-5f7c-4edc-83d5-a43c9973eefc"),
                   IsDeleted = false
               },
               new FishingPlace
               {
                   Id = new Guid("85b4ad4d-d97e-4407-b326-c9358c834197"),
                   Name = "Stara Zagora - Lake",
                   PictureURL = "https://media-cdn.tripadvisor.com/media/photo-s/0d/d5/96/49/park-hotel-stara-zagora.jpg",
                   Location = "Stara Zagora",
                   Description = "Zagorka Lake is a stunning park located in the heart of Stara Zagora, providing a peaceful retreat for both locals and tourists alike. As you enter the park, you are greeted by the shimmering waters of the lake, surrounded by lush greenery and vibrant flower beds that change with the seasons. The sound of birds chirping and the gentle rustling of leaves create a serene atmosphere, making it a perfect escape from the hustle and bustle of city life.The rezervation for fishing in this place is 3 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********",
                   UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                   TypeFishingId = new Guid("bc64e8ef-5f7c-4edc-83d5-a43c9973eefc"),
                   IsDeleted = false
               },
               new FishingPlace
               {
                   Id = new Guid("08c8ce8d-6ea4-44f3-9cb3-834c28cec800"),
                   Name = "Sozopol - Sea-Fishing",
                   PictureURL = "https://thumbs.dreamstime.com/z/light-fishing-boats-bulgarian-town-sozopol-ancient-seaside-famous-discoveries-slavic-settlements-located-past-black-130076552.jpg",
                   Location = "Sozopol",
                   Description = "Sozopol is a city in southeastern Bulgaria on the Black Sea . It is located on several small peninsulas in the southern part of the Burgas Bay . With a population of 6,428 people according to NSI data from December 31, 2019, the city is the eighth largest settlement in Burgas District and is the administrative center of Sozopol Municipality . The distance to Burgas is 34 km. It is the successor to the Greek colony of Apollonia and, together with Nessebar , is one of the oldest Bulgarian cities. .The rezervation for fishing in this place is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR CONTACT 088********",
                   UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                   TypeFishingId = new Guid("bd719745-fa48-4adc-bac1-0898a04e5822"),
                   IsDeleted = false
               },
               new FishingPlace
               {
                   Id = new Guid("22435c22-e9d0-4cc1-8de3-3e7a1e737c49"),
                   Name = "Madjarovo river-Fishing",
                   PictureURL = "https://oneflightaway.com/wp-content/uploads/2020/02/Kardzhali-Meander-2-1140x641.jpg",
                   Location = "Madjarovo",
                   Description = "The Arda (Bulgarian: Арда [ˈardɐ], Greek: Άρδας [ˈarðas], Turkish: Arda [ˈaɾda]) is a 290-kilometre-long (180 mi) river in Bulgaria and Greece.The Bulgarian section is 229 kilometres (142 mi) long,[1] making the Arda the longest river in the Rhodopes. The medieval Dyavolski most arch bridge crosses the river 10 kilometres (6 mi) from Ardino..The rezervation for fishing in this place is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR RESERVATION 088**********",
                   UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                   TypeFishingId = new Guid("12C8DD8d-346B-426E-B06C-75BBA97DCD63"),
                   IsDeleted = false
               }

               );
            builder
              .Entity<Hotel>()
              .HasData(
              new Hotel
              {
                  Id = new Guid("27da2b9c-1046-4c1a-bc15-7d3a9ae64d11"),
                  Name = "Studen kladenets-hotel",
                  PictureURL = "https://lh3.googleusercontent.com/p/AF1QipMHZMjQ3RzO4zeXWXeWsT_MUHbc2oO0MCZqcKQe=s294-w294-h220-n-k-no",
                  Location = "Studen kladenets",
                  Description = "The hotel have 25 rooms It is near to Lake and has resturant, swiming pool and many beautifull views.The rezervation for one people in this place is 2 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  FreePlace = 24,
                  Price = 180,
                  FishingPlaceId = new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16")


              },
              new Hotel
              {
                  Id = new Guid("713e37b1-057b-4f6f-9a9f-d41073379387"),
                  Name = "Stara Zagora - Hotel",
                  PictureURL = "https://lh3.googleusercontent.com/p/AF1QipORGURM7vRT8Ro6a9BEoCHeiotk2H6l3uh-9XHz=s184-w184-h144-n-k-no",
                  Location = "Stara Zagora",
                  Description = "The hotel have 35 rooms It is near to Lake and has resturant, swiming pool and many beautifull views.The rezervation for this place is 2 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  FreePlace = 31,
                  Price = 250,
                  FishingPlaceId = new Guid("85b4ad4d-d97e-4407-b326-c9358c834197")
              },
              new Hotel
              {
                  Id = new Guid("91b4dae2-2dd9-4348-a359-78b0e5215564"),
                  Name = "Sozopol - Hotel",
                  PictureURL = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0e/68/e4/b3/hotel-miramar.jpg?w=1200&h=-1&s=1",
                  Location = "Sozopol",
                  Description = " The hotel have 65 rooms It is near to sea and has resturants, swiming pools and many beautifull views.The rezervation for place is 2 days from 25.05.2024 to 27.05.2024 year.GSM FOR CONTACT 088********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  FreePlace = 45,
                  Price = 200,
                  FishingPlaceId = new Guid("08c8ce8d-6ea4-44f3-9cb3-834c28cec800")
              },
              new Hotel
              {
                  Id = new Guid("b2ef8518-6c34-4a46-9777-66111ae15659"),
                  Name = "Madjarovo river-Hotel",
                  PictureURL = "https://static.pochivka.bg/bgstay.com/images/photos/58/58295/new/pic_58295_1.jpg",
                  Location = "Madjarovo",
                  Description = "The hotel have 29 rooms It is near to Lake and has resturant, swiming pool and many beautifull views.The rezervation for this place is 2 days from 25.05.2024 to 27.05.2024 year.GSM FOR RESERVATION 088**********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  FreePlace = 19,
                  Price = 160,
                  FishingPlaceId = new Guid("22435c22-e9d0-4cc1-8de3-3e7a1e737c49")

              }

              );
            builder
              .Entity<Car>()
              .HasData(
              new Car
              {
                  Id = new Guid("c3024b49-c012-468b-8de2-2fdd004e8241"),
                  Model = "Volvo XC60",
                  PictureURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg",
                  Location = "Studen kladenets",
                  Details = "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags..The rezervation for this car for 3 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  AvelableCars = 21,
                  Price = 180,
                  FishingPlaceId = new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16")


              },
              new Car
              {
                  Id = new Guid("3e1e2203-065d-4613-ae25-5e715c91b83a"),
                  Model = "Volvo XC60",
                  PictureURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg",
                  Location = "Stara Zagora",
                  Details = "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags.The rezervation for car is 3 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  AvelableCars = 21,
                  Price = 180,
                  FishingPlaceId = new Guid("85b4ad4d-d97e-4407-b326-c9358c834197")
              },
              new Car
              {
                  Id = new Guid("2520e718-2e1a-4332-9fb4-85252436a712"),
                  Model = "Volvo XC60",
                  PictureURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg",
                  Location = "Sozopol",
                  Details = "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags. The rezervation for this car is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR CONTACT 088********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  AvelableCars = 21,
                  Price = 180,
                  FishingPlaceId = new Guid("08c8ce8d-6ea4-44f3-9cb3-834c28cec800")
              },
              new Car
              {
                  Id = new Guid("848bb4f1-c6e1-4030-ab88-0ee664f72dc5"),
                  Model = "Volvo XC60",
                  PictureURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg",
                  Location = "Madjarovo",
                  Details = "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags.The rezervation for this car is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR RESERVATION 088**********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  AvelableCars = 21,
                  Price = 180,
                  FishingPlaceId = new Guid("22435c22-e9d0-4cc1-8de3-3e7a1e737c49")

              });
            builder
              .Entity<Event>()
              .HasData(
              new Event
              {
                  Id = new Guid("c3024b49-c012-468b-8de2-2fdd004e8241"),
                  Name = "Drinking cups of wine",
                  ImageURL = "https://www.eatingwell.com/thmb/hmkghQ7jiNId8-LYlrpZBy1-MUM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/wine-gettyimages-160836693_1_0-f2322da3687d4dafbcbdd7d52cf86064.jpg",
                  Location = ".",
                  Description = "The Wine Festival is an event where wine, culture and cuisine merge into one, creating a space for those who love life in all its flavors, colors and shades. The city wine festival is dedicated to the diversity of local wine grape varieties, with which Bulgarian winemakers give the authentic appearance of Bulgarian wine.The rezervation for this event is for last day ot the fishingdays.GSM FOR RESERVATION 088*********",
                  UserId = "5285544d-9b67-485b-8c12-a5c776604044",
                  IsDeleted = false,
                  FreePlace = 50,
                  Price = 50,
                  FishingPlaceId = new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16")


              });

        }
    }
}
