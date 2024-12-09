using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FishingMania.Data.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FishingPlaces",
                columns: new[] { "Id", "Description", "IsDeleted", "Location", "Name", "PictureURL", "TypeFishingId", "UserId" },
                values: new object[,]
                {
                    { new Guid("08c8ce8d-6ea4-44f3-9cb3-834c28cec800"), "Sozopol is a city in southeastern Bulgaria on the Black Sea . It is located on several small peninsulas in the southern part of the Burgas Bay . With a population of 6,428 people according to NSI data from December 31, 2019, the city is the eighth largest settlement in Burgas District and is the administrative center of Sozopol Municipality . The distance to Burgas is 34 km. It is the successor to the Greek colony of Apollonia and, together with Nessebar , is one of the oldest Bulgarian cities. .The rezervation for fishing in this place is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR CONTACT 088********", false, "Sozopol", "Sozopol - Sea-Fishing", "https://thumbs.dreamstime.com/z/light-fishing-boats-bulgarian-town-sozopol-ancient-seaside-famous-discoveries-slavic-settlements-located-past-black-130076552.jpg", new Guid("bd719745-fa48-4adc-bac1-0898a04e5822"), "5285544d-9b67-485b-8c12-a5c776604044" },
                    { new Guid("22435c22-e9d0-4cc1-8de3-3e7a1e737c49"), "The Arda (Bulgarian: Арда [ˈardɐ], Greek: Άρδας [ˈarðas], Turkish: Arda [ˈaɾda]) is a 290-kilometre-long (180 mi) river in Bulgaria and Greece.The Bulgarian section is 229 kilometres (142 mi) long,[1] making the Arda the longest river in the Rhodopes. The medieval Dyavolski most arch bridge crosses the river 10 kilometres (6 mi) from Ardino..The rezervation for fishing in this place is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR RESERVATION 088**********", false, "Madjarovo", "Madjarovo river-Fishing", "https://oneflightaway.com/wp-content/uploads/2020/02/Kardzhali-Meander-2-1140x641.jpg", new Guid("12c8dd8d-346b-426e-b06c-75bba97dcd63"), "5285544d-9b67-485b-8c12-a5c776604044" },
                    { new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16"), "Studen kladenets (Cold well) is a reservoir in Eastern Rhodope Mountains, built on Arda river. It is part of a huge Communist project, implemented in the 1960-s, when many rivers in Bulgaria were damed, the flow of water obstructed with few villages stayed under water. The Arda project involves three big reservoirs and it is announced “Arda Cascade”.  Studen kladenets is in the middle.The rezervation for fishing in this place is 3 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********", false, "Studen kladenets", "Studen kladenets", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/467694130.jpg?k=694e5ed2ad33b65f2e3d3c34e5016b7d853416e0b8502bd5569db2d32c4fb8e5&o=", new Guid("bc64e8ef-5f7c-4edc-83d5-a43c9973eefc"), "5285544d-9b67-485b-8c12-a5c776604044" },
                    { new Guid("85b4ad4d-d97e-4407-b326-c9358c834197"), "Zagorka Lake is a stunning park located in the heart of Stara Zagora, providing a peaceful retreat for both locals and tourists alike. As you enter the park, you are greeted by the shimmering waters of the lake, surrounded by lush greenery and vibrant flower beds that change with the seasons. The sound of birds chirping and the gentle rustling of leaves create a serene atmosphere, making it a perfect escape from the hustle and bustle of city life.The rezervation for fishing in this place is 3 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********", false, "Stara Zagora", "Stara Zagora - Lake", "https://media-cdn.tripadvisor.com/media/photo-s/0d/d5/96/49/park-hotel-stara-zagora.jpg", new Guid("bc64e8ef-5f7c-4edc-83d5-a43c9973eefc"), "5285544d-9b67-485b-8c12-a5c776604044" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AvelableCars", "Details", "FishingPlaceId", "IsDeleted", "Location", "Model", "PictureURL", "Price", "UserId" },
                values: new object[,]
                {
                    { new Guid("2520e718-2e1a-4332-9fb4-85252436a712"), 21, "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags. The rezervation for this car is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR CONTACT 088********", new Guid("08c8ce8d-6ea4-44f3-9cb3-834c28cec800"), false, "Sozopol", "Volvo XC60", "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg", 180.0, "5285544d-9b67-485b-8c12-a5c776604044" },
                    { new Guid("3e1e2203-065d-4613-ae25-5e715c91b83a"), 21, "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags.The rezervation for car is 3 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********", new Guid("85b4ad4d-d97e-4407-b326-c9358c834197"), false, "Stara Zagora", "Volvo XC60", "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg", 180.0, "5285544d-9b67-485b-8c12-a5c776604044" },
                    { new Guid("848bb4f1-c6e1-4030-ab88-0ee664f72dc5"), 21, "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags.The rezervation for this car is 3 days from 25.05.2024 to 27.05.2024 year.GSM FOR RESERVATION 088**********", new Guid("22435c22-e9d0-4cc1-8de3-3e7a1e737c49"), false, "Madjarovo", "Volvo XC60", "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg", 180.0, "5285544d-9b67-485b-8c12-a5c776604044" },
                    { new Guid("c3024b49-c012-468b-8de2-2fdd004e8241"), 21, "Seating Capacity: It’s a five-seater SUV.Engine and Transmission: It is powered by a 2-litre, turbo-petrol, mild-hybrid engine delivering 250 PS and 350 Nm. The unit is linked to a 48-volt electric motor.Features: Key features include a 9-inch touchscreen infotainment system, 12-inch digital instrument cluster, a panoramic sunroof. Furthermore, the SUV boasts a heads-up display and wireless phone charging.Safety: The safety package includes adaptive cruise control, 360-degree camera, lane keep assist, collision warning and mitigation support, hill start assist, and multiple airbags..The rezervation for this car for 3 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********", new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16"), false, "Studen kladenets", "Volvo XC60", "https://stimg.cardekho.com/images/carexteriorimages/930x620/Volvo/XC60/10589/1689925663904/front-view-118.jpg", 180.0, "5285544d-9b67-485b-8c12-a5c776604044" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "FishingPlaceId", "FreePlace", "ImageURL", "IsDeleted", "Location", "Name", "Price", "UserId" },
                values: new object[] { new Guid("c3024b49-c012-468b-8de2-2fdd004e8241"), "The Wine Festival is an event where wine, culture and cuisine merge into one, creating a space for those who love life in all its flavors, colors and shades. The city wine festival is dedicated to the diversity of local wine grape varieties, with which Bulgarian winemakers give the authentic appearance of Bulgarian wine.The rezervation for this event is for last day ot the fishingdays.GSM FOR RESERVATION 088*********", new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16"), 50, "https://www.eatingwell.com/thmb/hmkghQ7jiNId8-LYlrpZBy1-MUM=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/wine-gettyimages-160836693_1_0-f2322da3687d4dafbcbdd7d52cf86064.jpg", false, ".", "Drinking cups of wine", 50.0, "5285544d-9b67-485b-8c12-a5c776604044" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Description", "FishingPlaceId", "FreePlace", "IsDeleted", "Location", "Name", "PictureURL", "Price", "UserId" },
                values: new object[,]
                {
                    { new Guid("27da2b9c-1046-4c1a-bc15-7d3a9ae64d11"), "The hotel have 25 rooms It is near to Lake and has resturant, swiming pool and many beautifull views.The rezervation for one people in this place is 2 days from 17.03.2024 to 19.03.2024 year.GSM FOR RESERVATION 088*********", new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16"), 24, false, "Studen kladenets", "Studen kladenets-hotel", "https://lh3.googleusercontent.com/p/AF1QipMHZMjQ3RzO4zeXWXeWsT_MUHbc2oO0MCZqcKQe=s294-w294-h220-n-k-no", 180.0, "5285544d-9b67-485b-8c12-a5c776604044" },
                    { new Guid("713e37b1-057b-4f6f-9a9f-d41073379387"), "The hotel have 35 rooms It is near to Lake and has resturant, swiming pool and many beautifull views.The rezervation for this place is 2 days from 25.03.2024 to 27.03.2024 year.GSM FOR RESERVATION 088**********", new Guid("85b4ad4d-d97e-4407-b326-c9358c834197"), 31, false, "Stara Zagora", "Stara Zagora - Hotel", "https://lh3.googleusercontent.com/p/AF1QipORGURM7vRT8Ro6a9BEoCHeiotk2H6l3uh-9XHz=s184-w184-h144-n-k-no", 250.0, "5285544d-9b67-485b-8c12-a5c776604044" },
                    { new Guid("91b4dae2-2dd9-4348-a359-78b0e5215564"), " The hotel have 65 rooms It is near to sea and has resturants, swiming pools and many beautifull views.The rezervation for place is 2 days from 25.05.2024 to 27.05.2024 year.GSM FOR CONTACT 088********", new Guid("08c8ce8d-6ea4-44f3-9cb3-834c28cec800"), 45, false, "Sozopol", "Sozopol - Hotel", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/0e/68/e4/b3/hotel-miramar.jpg?w=1200&h=-1&s=1", 200.0, "5285544d-9b67-485b-8c12-a5c776604044" },
                    { new Guid("b2ef8518-6c34-4a46-9777-66111ae15659"), "The hotel have 29 rooms It is near to Lake and has resturant, swiming pool and many beautifull views.The rezervation for this place is 2 days from 25.05.2024 to 27.05.2024 year.GSM FOR RESERVATION 088**********", new Guid("22435c22-e9d0-4cc1-8de3-3e7a1e737c49"), 19, false, "Madjarovo", "Madjarovo river-Hotel", "https://static.pochivka.bg/bgstay.com/images/photos/58/58295/new/pic_58295_1.jpg", 160.0, "5285544d-9b67-485b-8c12-a5c776604044" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("2520e718-2e1a-4332-9fb4-85252436a712"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("3e1e2203-065d-4613-ae25-5e715c91b83a"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("848bb4f1-c6e1-4030-ab88-0ee664f72dc5"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c3024b49-c012-468b-8de2-2fdd004e8241"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("c3024b49-c012-468b-8de2-2fdd004e8241"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("27da2b9c-1046-4c1a-bc15-7d3a9ae64d11"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("713e37b1-057b-4f6f-9a9f-d41073379387"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("91b4dae2-2dd9-4348-a359-78b0e5215564"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("b2ef8518-6c34-4a46-9777-66111ae15659"));

            migrationBuilder.DeleteData(
                table: "FishingPlaces",
                keyColumn: "Id",
                keyValue: new Guid("08c8ce8d-6ea4-44f3-9cb3-834c28cec800"));

            migrationBuilder.DeleteData(
                table: "FishingPlaces",
                keyColumn: "Id",
                keyValue: new Guid("22435c22-e9d0-4cc1-8de3-3e7a1e737c49"));

            migrationBuilder.DeleteData(
                table: "FishingPlaces",
                keyColumn: "Id",
                keyValue: new Guid("482aae12-9844-4e73-9af2-52e5c4d09f16"));

            migrationBuilder.DeleteData(
                table: "FishingPlaces",
                keyColumn: "Id",
                keyValue: new Guid("85b4ad4d-d97e-4407-b326-c9358c834197"));
        }
    }
}
