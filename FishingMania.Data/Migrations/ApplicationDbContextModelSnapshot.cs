﻿// <auto-generated />
using System;
using FishingMania.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FishingMania.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FishingMania.Data.Models.ApplicationUserFishingPlace", b =>
                {
                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("FishingPlaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ApplicationUserId", "FishingPlaceId");

                    b.HasIndex("FishingPlaceId");

                    b.ToTable("ApplicationUsersFishingPlaces");
                });

            modelBuilder.Entity("FishingMania.Data.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvelableCars")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("FishingPlaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FishingPlaceId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c3024b49-c012-468b-8de2-2fdd004e8241"),
                            AvelableCars = 21,
                            Details = "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags..The rezervation for this car for 3 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********",
                            FishingPlaceId = new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16"),
                            IsDeleted = false,
                            Location = "Studen kladenets",
                            Model = "Volvo XC60",
                            PictureURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg",
                            Price = 180.0,
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        },
                        new
                        {
                            Id = new Guid("3e1e2203-065d-4613-ae25-5e715c91b83a"),
                            AvelableCars = 21,
                            Details = "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags.The rezervation for car is 3 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********",
                            FishingPlaceId = new Guid("85b4ad4d-d97e-4407-b326-c9358c834197"),
                            IsDeleted = false,
                            Location = "Stara Zagora",
                            Model = "Volvo XC60",
                            PictureURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg",
                            Price = 180.0,
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        },
                        new
                        {
                            Id = new Guid("2520e718-2e1a-4332-9fb4-85252436a712"),
                            AvelableCars = 21,
                            Details = "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags. The rezervation for this car is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR CONTACT 088********",
                            FishingPlaceId = new Guid("08c8ce8d-6ea4-44f3-9cb3-834c28cec800"),
                            IsDeleted = false,
                            Location = "Sozopol",
                            Model = "Volvo XC60",
                            PictureURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg",
                            Price = 180.0,
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        },
                        new
                        {
                            Id = new Guid("848bb4f1-c6e1-4030-ab88-0ee664f72dc5"),
                            AvelableCars = 21,
                            Details = "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags.The rezervation for this car is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR RESERVATION 088**********",
                            FishingPlaceId = new Guid("22435c22-e9d0-4cc1-8de3-3e7a1e737c49"),
                            IsDeleted = false,
                            Location = "Madjarovo",
                            Model = "Volvo XC60",
                            PictureURL = "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg",
                            Price = 180.0,
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        });
                });

            modelBuilder.Entity("FishingMania.Data.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("FishingPlaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FreePlace")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FishingPlaceId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c3024b49-c012-468b-8de2-2fdd004e8241"),
                            Description = "The Wine Festival is an event where wine, culture and cuisine merge into one, creating a space for those who love life in all its flavors, colors and shades. The city wine festival is dedicated to the diversity of local wine grape varieties, with which Bulgarian winemakers give the authentic appearance of Bulgarian wine.The rezervation for this event is for last day ot the fishingdays.GSM FOR RESERVATION 088*********",
                            FishingPlaceId = new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16"),
                            FreePlace = 50,
                            ImageURL = "https://www.eatingwell.com/thmb/hmkghQ7jiNId8-LYlrpZBy1-MUM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/wine-gettyimages-160836693_1_0-f2322da3687d4dafbcbdd7d52cf86064.jpg",
                            IsDeleted = false,
                            Location = ".",
                            Name = "Drinking cups of wine",
                            Price = 50.0,
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        });
                });

            modelBuilder.Entity("FishingMania.Data.Models.FishingPlace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeFishingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TypeFishingId");

                    b.HasIndex("UserId");

                    b.ToTable("FishingPlaces");

                    b.HasData(
                        new
                        {
                            Id = new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16"),
                            Description = "Studen kladenets (Cold well) is a reservoir in Eastern Rhodope Mountains, built on Arda river. It is part of a huge Communist project, implemented in the 1960-s, when many rivers in Bulgaria were damed, the flow of water obstructed with few villages stayed under water. The Arda project involves three big reservoirs and it is announced “Arda Cascade”.  Studen kladenets is in the middle.The rezervation for fishing in this place is 3 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********",
                            IsDeleted = false,
                            Location = "Studen kladenets",
                            Name = "Studen kladenets",
                            PictureURL = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/467694130.jpg?k=694e5ed2ad33b65f2e3d3c34e5016b7d853416e0b8502bd5569db2d32c4fb8e5&o=",
                            TypeFishingId = new Guid("bc64e8ef-5f7c-4edc-83d5-a43c9973eefc"),
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        },
                        new
                        {
                            Id = new Guid("85b4ad4d-d97e-4407-b326-c9358c834197"),
                            Description = "Zagorka Lake is a stunning park located in the heart of Stara Zagora, providing a peaceful retreat for both locals and tourists alike. As you enter the park, you are greeted by the shimmering waters of the lake, surrounded by lush greenery and vibrant flower beds that change with the seasons. The sound of birds chirping and the gentle rustling of leaves create a serene atmosphere, making it a perfect escape from the hustle and bustle of city life.The rezervation for fishing in this place is 3 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********",
                            IsDeleted = false,
                            Location = "Stara Zagora",
                            Name = "Stara Zagora - Lake",
                            PictureURL = "https://media-cdn.tripadvisor.com/media/photo-s/0d/d5/96/49/park-hotel-stara-zagora.jpg",
                            TypeFishingId = new Guid("bc64e8ef-5f7c-4edc-83d5-a43c9973eefc"),
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        },
                        new
                        {
                            Id = new Guid("08c8ce8d-6ea4-44f3-9cb3-834c28cec800"),
                            Description = "Sozopol is a city in southeastern Bulgaria on the Black Sea . It is located on several small peninsulas in the southern part of the Burgas Bay . With a population of 6,428 people according to NSI data from December 31, 2019, the city is the eighth largest settlement in Burgas District and is the administrative center of Sozopol Municipality . The distance to Burgas is 34 km. It is the successor to the Greek colony of Apollonia and, together with Nessebar , is one of the oldest Bulgarian cities. .The rezervation for fishing in this place is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR CONTACT 088********",
                            IsDeleted = false,
                            Location = "Sozopol",
                            Name = "Sozopol - Sea-Fishing",
                            PictureURL = "https://thumbs.dreamstime.com/z/light-fishing-boats-bulgarian-town-sozopol-ancient-seaside-famous-discoveries-slavic-settlements-located-past-black-130076552.jpg",
                            TypeFishingId = new Guid("bd719745-fa48-4adc-bac1-0898a04e5822"),
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        },
                        new
                        {
                            Id = new Guid("22435c22-e9d0-4cc1-8de3-3e7a1e737c49"),
                            Description = "The Arda (Bulgarian: Арда [ˈardɐ], Greek: Άρδας [ˈarðas], Turkish: Arda [ˈaɾda]) is a 290-kilometre-long (180 mi) river in Bulgaria and Greece.The Bulgarian section is 229 kilometres (142 mi) long,[1] making the Arda the longest river in the Rhodopes. The medieval Dyavolski most arch bridge crosses the river 10 kilometres (6 mi) from Ardino..The rezervation for fishing in this place is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR RESERVATION 088**********",
                            IsDeleted = false,
                            Location = "Madjarovo",
                            Name = "Madjarovo river-Fishing",
                            PictureURL = "https://oneflightaway.com/wp-content/uploads/2020/02/Kardzhali-Meander-2-1140x641.jpg",
                            TypeFishingId = new Guid("12c8dd8d-346b-426e-b06c-75bba97dcd63"),
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        });
                });

            modelBuilder.Entity("FishingMania.Data.Models.Hotel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("FishingPlaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FreePlace")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FishingPlaceId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("27da2b9c-1046-4c1a-bc15-7d3a9ae64d11"),
                            Description = "The hotel have 25 rooms It is near to Lake and has resturant, swiming pool and many beautifull views.The rezervation for one people in this place is 2 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********",
                            FishingPlaceId = new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16"),
                            FreePlace = 24,
                            IsDeleted = false,
                            Location = "Studen kladenets",
                            Name = "Studen kladenets-hotel",
                            PictureURL = "https://lh3.googleusercontent.com/p/AF1QipMHZMjQ3RzO4zeXWXeWsT_MUHbc2oO0MCZqcKQe=s294-w294-h220-n-k-no",
                            Price = 180.0,
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        },
                        new
                        {
                            Id = new Guid("713e37b1-057b-4f6f-9a9f-d41073379387"),
                            Description = "The hotel have 35 rooms It is near to Lake and has resturant, swiming pool and many beautifull views.The rezervation for this place is 2 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********",
                            FishingPlaceId = new Guid("85b4ad4d-d97e-4407-b326-c9358c834197"),
                            FreePlace = 31,
                            IsDeleted = false,
                            Location = "Stara Zagora",
                            Name = "Stara Zagora - Hotel",
                            PictureURL = "https://lh3.googleusercontent.com/p/AF1QipORGURM7vRT8Ro6a9BEoCHeiotk2H6l3uh-9XHz=s184-w184-h144-n-k-no",
                            Price = 250.0,
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        },
                        new
                        {
                            Id = new Guid("91b4dae2-2dd9-4348-a359-78b0e5215564"),
                            Description = " The hotel have 65 rooms It is near to sea and has resturants, swiming pools and many beautifull views.The rezervation for place is 2 days from 25.05.2024 to 27.05.2024 year.GSM FOR CONTACT 088********",
                            FishingPlaceId = new Guid("08c8ce8d-6ea4-44f3-9cb3-834c28cec800"),
                            FreePlace = 45,
                            IsDeleted = false,
                            Location = "Sozopol",
                            Name = "Sozopol - Hotel",
                            PictureURL = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0e/68/e4/b3/hotel-miramar.jpg?w=1200&h=-1&s=1",
                            Price = 200.0,
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        },
                        new
                        {
                            Id = new Guid("b2ef8518-6c34-4a46-9777-66111ae15659"),
                            Description = "The hotel have 29 rooms It is near to Lake and has resturant, swiming pool and many beautifull views.The rezervation for this place is 2 days from 25.05.2024 to 27.05.2024 year.GSM FOR RESERVATION 088**********",
                            FishingPlaceId = new Guid("22435c22-e9d0-4cc1-8de3-3e7a1e737c49"),
                            FreePlace = 19,
                            IsDeleted = false,
                            Location = "Madjarovo",
                            Name = "Madjarovo river-Hotel",
                            PictureURL = "https://static.pochivka.bg/bgstay.com/images/photos/58/58295/new/pic_58295_1.jpg",
                            Price = 160.0,
                            UserId = "5285544d-9b67-485b-8c12-a5c776604044"
                        });
                });

            modelBuilder.Entity("FishingMania.Data.Models.TypesFishing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TypesFishings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("12c8dd8d-346b-426e-b06c-75bba97dcd63"),
                            Name = "RiverFishing"
                        },
                        new
                        {
                            Id = new Guid("bc64e8ef-5f7c-4edc-83d5-a43c9973eefc"),
                            Name = "LakeFishing"
                        },
                        new
                        {
                            Id = new Guid("bd719745-fa48-4adc-bac1-0898a04e5822"),
                            Name = "SeaFishing"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FishingMania.Data.Models.ApplicationUserFishingPlace", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FishingMania.Data.Models.FishingPlace", "FishingPlaces")
                        .WithMany("ApplicationUserFishingPlaces")
                        .HasForeignKey("FishingPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("FishingPlaces");
                });

            modelBuilder.Entity("FishingMania.Data.Models.Car", b =>
                {
                    b.HasOne("FishingMania.Data.Models.FishingPlace", "FishingPlace")
                        .WithMany("Cars")
                        .HasForeignKey("FishingPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FishingPlace");
                });

            modelBuilder.Entity("FishingMania.Data.Models.Event", b =>
                {
                    b.HasOne("FishingMania.Data.Models.FishingPlace", "FishingPlace")
                        .WithMany("Events")
                        .HasForeignKey("FishingPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FishingPlace");
                });

            modelBuilder.Entity("FishingMania.Data.Models.FishingPlace", b =>
                {
                    b.HasOne("FishingMania.Data.Models.TypesFishing", "TypesFishing")
                        .WithMany("FishingPlaces")
                        .HasForeignKey("TypeFishingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TypesFishing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FishingMania.Data.Models.Hotel", b =>
                {
                    b.HasOne("FishingMania.Data.Models.FishingPlace", "FishingPlace")
                        .WithMany("Hotels")
                        .HasForeignKey("FishingPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FishingPlace");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FishingMania.Data.Models.FishingPlace", b =>
                {
                    b.Navigation("ApplicationUserFishingPlaces");

                    b.Navigation("Cars");

                    b.Navigation("Events");

                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("FishingMania.Data.Models.TypesFishing", b =>
                {
                    b.Navigation("FishingPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}
