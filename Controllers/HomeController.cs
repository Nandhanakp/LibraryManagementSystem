using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NewFolder.Controllers;

public class HomeController : BaseController
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
{
    return View();
}


    public IActionResult Books()
    {
        return View();
    }

    public IActionResult Events()
    {
        return View();
    }

    public IActionResult Members()
    {
        return View();
    }

    public IActionResult Services()
    {
        return View();
    }

    public IActionResult Contact()
{
    if (HttpContext.Session.GetString("Role") != "Member")
        return RedirectToAction("Login", "Account");

    return View("~/Views/Contact/Index.cshtml");
}
public IActionResult Messages()
{
    if (HttpContext.Session.GetString("Role") != "Staff")
        return RedirectToAction("Login", "Account");

    return View("~/Views/Messages/Index.cshtml");
}

}
