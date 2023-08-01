//using RestSharp;
//using Newtonsoft.Json;
//using Microsoft.AspNetCore.Mvc;
//using NuGet.Protocol;
//using AppContainer.Models;

//public class WeatherController : Controller 
//{
//    public async Task<IActionResult> SearchWeather(string value)
//    {
//        var client = new HttpClient();
//        var res = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={value}&appid=87ee4861727771a1ce31609f31e5be98(&units=metric&lang=tr");
//        if (res.StatusCode == System.Net.HttpStatusCode.OK)
//        {

//            var json = await res.Content.ReadAsStringAsync();
//            var timeEdit = WeatherModels.FromJson(json);
//            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);


//            return PartialView("_WeatherDataPartial", timeEdit);

//        }
//        return NoContent();
//    }
//    public const string ApiKey = "7456a23625188ed9dbd6ebfa21bd9703"; // OpenWeatherMap API anahtarınızı buraya ekleyin.

//    public async Task<ActionResult> Index()
//    {

//        IList<string> Apicities = new List<string>();
//        Apicities.Add("sakarya");
//        Apicities.Add("istanbul");
//        Apicities.Add("ankara");
//        Apicities.Add("milano");

//        IList<WeatherModels> ApiResults = new List<WeatherModels>();
//        using var client = new HttpClient();
//        foreach (var apiCity in Apicities)
//        {
//            var res =  await client.GetAsync($"/*http://api.openweathermap.org/data/2.5/weather?q={apiCity}&a*/ppid={ApiKey}&units=metric&lang=tr");
//            if(res.IsSuccessStatusCode)
//            {
//                var json = await res.Content.ReadAsStringAsync();
//                var weather = WeatherModels.FromJson(json);
//                ApiResults.Add(weather);
//            }

//        }
//        return View(ApiResults);

//    }








//public async Task<WeatherViewModel?> GetWeatherData(string city)
//{

//    using var client = new HttpClient();
//   var response= await client.GetAsync($/*"http://api.openweathermap.org/data/2.5/weather?q={cit*/y}&appid={ApiKey}&units=metric");




//    if( response.IsSuccessStatusCode)
//    {
//        var data =await  response.Content.ReadAsStringAsync();
//        var weather=  WeatherModels.FromJson(data);
//        return data;
//    }
//    else
//    {
//        // API'den veri alınamazsa, boş bir WeatherDataModel döndürülebilir ya da hata mesajı gösterilebilir.
//        return null;
//    }
//    //}
//}
using AppContainer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppContainer.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var apiKey = "7456a23625188ed9dbd6ebfa21bd9703";
            var CityWeathers = new List<WeatherModel>();
            List<string> Cities = new List<string>();
            Cities.Add("London");
            Cities.Add("Istanbul");
            Cities.Add("Berlin");
            Cities.Add("Tokyo");
            var _httpClient = new HttpClient();
            foreach (var cityname in Cities)
            {
                var response = await _httpClient.GetAsync($"\"http://api.openweathermap.org/data/2.5/weather?q={cityname}&appid={apiKey}");
                var WeatherJson = await response.Content.ReadAsStringAsync();
                var CityObject = WeatherModel.FromJson(WeatherJson);
                CityWeathers.Add(CityObject);
            }
            return View(CityWeathers);
        }
    }
}