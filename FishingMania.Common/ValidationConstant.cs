using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingMania.Common
{
    public static class ValidationConstant
    {
        //all
        public const string TimeFormat = "dd/MM/yyyy";

        //fishing place
        public const int PlaceNameMax = 100;
        public const int PlaceNameMin = 3;
        public const int PlaceLocationMax = 100;
        public const int PlaceLocationMin = 3;
        public const int PlaceDescriptionMax = 1000;
        public const int PlaceDescriptionMin = 3;


        //car
        public const int CarModelMax = 100;
        public const int CarModelMin = 3;
        public const int CarLocationMax = 100;
        public const int CarLocationMin = 3;
        public const int CarDescriptionMax = 1000;
        public const int CarDescriptionMin = 3;


        //Event 
        public const int EventNameMax = 100;
        public const int EventNameMin = 3;
        public const int EventLocationMax = 100;
        public const int EventLocationMin = 3;
        public const int EventDescriptionMax = 1000;
        public const int EventDescriptionMin = 3;

        //Type Fishing
        public const int TypeNameMax = 50;
        public const int TypeNameMin = 3;

        //Hotel
        public const int HotelNameMax = 100;
        public const int HotelNameMIn = 3;
        public const int HotelLocationMax = 100;
        public const int HotelLocationMin= 3;
        public const int HotelDescriptionMax = 500;
        public const int HotelDescriptionMIn = 20;
        //Admin
        public const string AdminRoleName = "Admin";
    }
}
