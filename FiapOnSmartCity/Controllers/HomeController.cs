using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace FiapOnSmartCity.Controllers;

public class HomeController : Controller
{
    //GET : Home
    public ActionResult Index()
    {
        return View();
    }
}
