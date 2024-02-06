using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Makaan.MVC.Models.Enums;

namespace Makaan.MVC.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Streat { get; set; }
        public float Area { get; set; }
        public string? ImageUrl { get; set; }
        public int NumOfRooms { get; set; }
        public int NumOfBaths { get; set; }
        public PlaceStatus Status { get; set; }
        public PlaceType Type { get; set; }
    }
}