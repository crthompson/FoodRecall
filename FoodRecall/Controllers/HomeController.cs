using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FoodRecall.Models;
using FoodRecall.Service;
using System.Threading.Tasks;

namespace FoodRecall.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.StartDate = "";
        ViewBag.EndDate = "";
        ViewBag.Limit = 0;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(DateTime startDate, DateTime endDate, int limit)
    {
        ViewBag.StartDate = startDate.ToString("MM/dd/yyyy");
        ViewBag.EndDate = endDate.ToString("MM/dd/yyyy");
        ViewBag.Limit = limit;
                
        try
        {
            var service = new FoodRecallService(_httpClientFactory);
            var results = await service.GetResults(startDate, endDate, limit);
            return View(results);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", new { errorMessage = ex.Message });
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(string errorMessage)
    {
        Response.StatusCode = 404;
        return View(new ErrorViewModel { 
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, 
            ErrorMessage = errorMessage });        
    }
}
