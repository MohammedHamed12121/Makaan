using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Makaan.MVC.Data;
using Makaan.MVC.Models;
using Makaan.MVC.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Makaan.MVC.Controllers
{
    [Authorize]
    public class PlaceController : Controller
    {
        private readonly ILogger<PlaceController> _logger;
    private readonly ApplicationDbContext _context;

        public PlaceController(ILogger<PlaceController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // TODO: Make all this parameter an object
        [HttpGet][HttpPost]
        public IActionResult Index(PlaceStatus? st, PlaceType? ty, string? searchTerm)
        {
            // get the places as ienumrable
            IEnumerable<Place> placesEnum;
            placesEnum = _context.Places;

            // check for status filter
            if(st is not null)
            {
                placesEnum = placesEnum.Where(p => p.Status == st);
            }

            // check for type filter
            if(ty is not null)
            {
                placesEnum = placesEnum.Where(p => p.Type == ty);
            }

            // check for the search filter
            if(searchTerm is not null)
            {
                placesEnum = placesEnum.Where(p => 
                                                (p.Title is not null ? p.Title.Contains(searchTerm) : p.Title is null) || 
                                                (p.Description is not null ? p.Description.Contains(searchTerm) : p.Description is null)
                                            );
            }
            // return the view
            var places = placesEnum.ToList();
            return View(places);
        }

        public async Task<IActionResult> Details(int id)
        {
            // get the place  and return it to the view
            var place = await _context.Places
                                       .AsNoTracking()
                                        .Where(p => p.Id == id)
                                        .FirstOrDefaultAsync();
            return View(place);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}