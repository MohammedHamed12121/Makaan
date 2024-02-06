using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Makaan.MVC.Models;
using Makaan.MVC.Data;
using Makaan.MVC.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Makaan.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;


    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {

        var places = await _context.Places
                                    .Take(6)
                                    .AsNoTracking()
                                    .ToListAsync();
        return View(places);
    }

    [HttpPost]
    public async Task<IActionResult> Index(PlaceStatus? status)
    {

        var places = status is null 
                            ? await _context
                                    .Places
                                    .Take(6)
                                    .AsNoTracking()
                                    .ToListAsync()
                            : await _context.Places
                                    .Take(6)
                                    .Where(p => p.Status == status)
                                    .AsNoTracking()
                                    .ToListAsync();
        return View(places);
    }

                                
                                

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
