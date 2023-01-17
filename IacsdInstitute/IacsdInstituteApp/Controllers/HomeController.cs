using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IacsdInstituteApp.Models;
using BOL;
using BLL;


namespace IacsdInstituteApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
      public IActionResult Insert()
    {
        return View();
    }
    [HttpPost]
     public IActionResult PostInsert(string firstname,string lastname, string email, string password)
    {
        User user=new User(){Firstname=firstname,Lastname=lastname,Email=email,Password=password};
        Usermanager.InsertUser(user);
        return Redirect("/Home/Index");
    }

     public IActionResult ShowAll()
    {
        Usermanager usermanager=new Usermanager();
        this.ViewData["AllUsers"]=usermanager.GetAllUsers();
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
