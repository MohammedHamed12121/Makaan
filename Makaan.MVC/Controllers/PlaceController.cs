using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Makaan.MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Makaan.MVC.Controllers
{
    public class PlaceController : Controller
    {
        private readonly ILogger<PlaceController> _logger;
    private readonly ApplicationDbContext _context;

        public PlaceController(ILogger<PlaceController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // get all places and return them to the view
            var places = await _context.Places
                                       .AsNoTracking()
                                       .ToListAsync();
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