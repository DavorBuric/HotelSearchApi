﻿namespace HotelSearch.API.Models
{
    public class SearchParametersModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}