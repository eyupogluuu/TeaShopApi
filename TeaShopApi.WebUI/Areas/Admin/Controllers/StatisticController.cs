using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> statisticList()
        {
            var client = _httpClientFactory.CreateClient();

            var responsemessage1 = await client.GetAsync("https://localhost:7271/api/Statistic/GetDrinkAvaragePrice");//apinin adresi
            var jsondata1 = await responsemessage1.Content.ReadAsStringAsync();
            ViewBag.v1 = jsondata1;

            var responsemessage2 = await client.GetAsync("https://localhost:7271/api/Statistic/GetDrinkCount");//apinin adresi
            var jsondata2 = await responsemessage2.Content.ReadAsStringAsync();
            ViewBag.v2 = jsondata2;

            var responsemessage3 = await client.GetAsync("https://localhost:7271/api/Statistic/GetLastDrinkName");//apinin adresi
            var jsondata3 = await responsemessage3.Content.ReadAsStringAsync();
            ViewBag.v3 = jsondata3;

            var responsemessage4 = await client.GetAsync("https://localhost:7271/api/Statistic/GetContactCount");//apinin adresi
            var jsondata4 = await responsemessage4.Content.ReadAsStringAsync();
            ViewBag.v4 = jsondata4;

            var responsemessage5 = await client.GetAsync("https://localhost:7271/api/Statistic/GetLastQuestion");//apinin adresi
            var jsondata5 = await responsemessage5.Content.ReadAsStringAsync();
            ViewBag.v5 = jsondata5;

            var responsemessage6 = await client.GetAsync("https://localhost:7271/api/Statistic/GetLastTestimonialName");//apinin adresi
            var jsondata6 = await responsemessage6.Content.ReadAsStringAsync();
            ViewBag.v6 = jsondata6;

            var responsemessage7 = await client.GetAsync("https://localhost:7271/api/Statistic/GetQuestionCount");//apinin adresi
            var jsondata7 = await responsemessage7.Content.ReadAsStringAsync();
            ViewBag.v7 = jsondata7;

            var responsemessage8 = await client.GetAsync("https://localhost:7271/api/Statistic/GetTestimonialCount");//apinin adresi
            var jsondata8 = await responsemessage8.Content.ReadAsStringAsync();
            ViewBag.v8 = jsondata8;

            return View();
        }
    }
}
