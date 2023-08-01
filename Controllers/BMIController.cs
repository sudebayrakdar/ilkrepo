//using Microsoft.AspNetCore.Mvc;

//namespace AppContainer.Controllers
//{
//    public class CalculatorController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
using AppContainer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;

namespace AppContainer.Controllers
{
    public class BMIController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(BMIModel appItem)
        {

            appItem.BMI = appItem.Weight / (float)Math.Pow(appItem.Height / 100, 2);

            if (appItem.BMI < 18) appItem.BMIRange = "UnderWeight";
            else if (appItem.BMI > 18 && appItem.BMI <= 24.9) appItem.BMIRange = "HealthyWeight";
            else if (appItem.BMI > 24.9 && appItem.BMI <= 29.9) appItem.BMIRange = "OverWeight";
            else if (appItem.BMI > 29.9) appItem.BMIRange = "Obese";


            var objectBMI = JsonConvert.SerializeObject(appItem);

            return Json(objectBMI);
        }

    }
}