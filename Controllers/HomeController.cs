using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQEruption.Models;

namespace LINQEruption.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Eruption> eruptions = new List<Eruption>()
        {
            new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
            new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
            new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
            new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
            new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
            new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
            new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
            new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
            new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
            new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
            new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
            new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
            new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
        };
        
        ViewBag.StratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
        ViewBag.FirstChileEruption = eruptions.FirstOrDefault(e => e.Location == "Chile");
        ViewBag.FirstHawaiianEruption = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
        ViewBag.FirstGreenlandEruption = eruptions.FirstOrDefault(e => e.Location == "Greenland");
        ViewBag.FirstEruptionAfter1900InNZ = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
        ViewBag.HighElevationEruptions = eruptions.Where(e => e.ElevationInMeters > 2000);
        ViewBag.EruptionsStartingWithL = eruptions.Where(e => e.Volcano.StartsWith("L", StringComparison.OrdinalIgnoreCase)).ToList();
        ViewBag.HighestElevation = eruptions.Max(e => e.ElevationInMeters);
        ViewBag.VolcanoWithHighestElevation = eruptions.First(e => e.ElevationInMeters == eruptions.Max(ev => ev.ElevationInMeters)).Volcano;
        ViewBag.VolcanoNamesAlphabetically = eruptions.OrderBy(e => e.Volcano);
        ViewBag.SumOfElevations = eruptions.Sum(e => e.ElevationInMeters);
        ViewBag.AnyEruptionsInYear2000 = eruptions.Any(e => e.Year == 2000);
        ViewBag.FirstThreeStratovolcanoes = eruptions.Where(e => e.Type == "Stratovolcano").Take(3);
        ViewBag.EruptionsBeforeYear1000Alphabetically = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
        ViewBag.EruptionNamesBeforeYear1000 = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano);

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
