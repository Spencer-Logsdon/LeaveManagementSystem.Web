using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LeaveManagementSystem.Web.Models;

namespace LeaveManagementSystem.Web.Controllers;

//Address then controller for ex(home Controller, about controller)
public class HomeController : Controller
{
    public IActionResult Index()
    {
        //Define business logic
        //Return view
        return View();
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
