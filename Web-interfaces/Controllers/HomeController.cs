using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;
using Web_interfaces.Data;
using Web_interfaces.Filters;
namespace Web_interfaces.Controllers
{
    public class HomeController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine("asdasd");
           foreach (Book  a in Search.SearchMain())
            {
                Console.WriteLine(a.Author);
            }
            return View();
        }
    }
}
