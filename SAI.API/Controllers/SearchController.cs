using Microsoft.AspNetCore.Mvc;

namespace SAI.API.Controllers;

public class SearchController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}