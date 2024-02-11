using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Makaan.MVC.Models;

namespace Makaan.MVC.ViewModel
{
    public class PlacesVM
    {
        public IEnumerable<Place>? Places { get; set; }
        
    }
}