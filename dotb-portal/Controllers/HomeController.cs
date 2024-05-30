using dotb.Portal;
using dotb_portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dotb_portal.Controllers;

public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) {
        _logger = logger;
    }

    public IActionResult Maintenance() {
        return View(new AddGlitterVM());
    }

    [HttpPost]
    public IActionResult Maintenance(AddGlitterVM posted) {
        if (posted.GlitterData == null) {
            ModelState.AddModelError("GlitterData", "Please select a file to upload.");
        }
        using MemoryStream ms = new MemoryStream();
        posted.GlitterData.CopyTo(ms);
        ms.Position = 0;
        byte[] bytesRead = ms.ToArray();

        return View(new AddGlitterVM());
    }

    public IActionResult Index() {
        return View();
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}