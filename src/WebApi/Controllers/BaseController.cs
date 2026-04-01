using Components.Framework.ApiResultFilter;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
public class BaseController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
