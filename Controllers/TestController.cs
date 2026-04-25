using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: TestController
        public ActionResult Index()
        {
            var data = new TestViewModel
            {
                Name = "Spencer",
                Age = 26,
                DateOfBirth = new DateTime(1999, 10, 20)
            };
            return View(data);
            
        }

    }
}
