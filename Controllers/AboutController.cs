using Microsoft.AspNetCore.Mvc;
using NewFolder.Controllers;

namespace NewFolder.Controllers
{
    public class AboutController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
