using AppContainer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppContainer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model=new List<AppContainerModel>();
            model.Add(new AppContainerModel {AppName="To Do List",Image= "/img/ToDoList_.webp",AppController="ToDoList",AppAction="Index",AppText= "You can create and add any list you want. When you give up on the list, you can delete that list." });
            model.Add(new AppContainerModel { AppName = "Body Mass Index", Image = "/img/body.jpg", AppController = "BMI", AppAction = "Index",AppText= "It is an application that calculates body mass index according to height and weight input." });
            model.Add(new AppContainerModel { AppName = "Weather App", Image = "/img/havaa.jpg", AppController = "Weather", AppAction = "Index", AppText = "It is an application that brings the weather information of a randomly entered city instantly. " });
            model.Add(new AppContainerModel {AppName="Random Quotations",Image= "/img/ağaç.jpg", AppController="RandomQuotes",AppAction="Index",AppText= "User can access a random quote and share it on twitter account." });
            return View(model);
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
}