using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ErrorController : Controller
{
    private const string ViewUrl = "~/View/Error/index.cshtml";

    // GET
    public IActionResult Index()
    {
        return View(ViewUrl);
    }
}
