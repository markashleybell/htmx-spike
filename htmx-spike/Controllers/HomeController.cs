using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using htmx_spike.Models;
using Htmx;
using Microsoft.AspNetCore.Http.Extensions;

namespace htmx_spike.Controllers;

public class HomeController : Controller
{
    private static readonly string[] SearchData = new[]
    {
        "cat",
        "dog",
        "fish",
        "catfish",
        "dogfish"
    };

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Search(SearchViewModel model)
    {
        if (!string.IsNullOrWhiteSpace(model?.Query))
        {
            model.Results = SearchData.Where(sd => sd.Contains(model.Query, StringComparison.OrdinalIgnoreCase));
        }

        return View(model);
    }

    public async Task<IActionResult> SearchResults(SearchViewModel model)
    {
        if (!string.IsNullOrWhiteSpace(model?.Query))
        {
            model.Results = SearchData.Where(sd => sd.Contains(model.Query, StringComparison.OrdinalIgnoreCase));
        }

        Response.Htmx(h =>
        {
            h.Trigger("headingUpdate");
            h.Push(Request.GetEncodedUrl().Replace("Results", string.Empty));
        });

        if (Request.IsHtmx())
        {
            await Task.Delay(500);
        }

        return PartialView("_SearchResults", model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
