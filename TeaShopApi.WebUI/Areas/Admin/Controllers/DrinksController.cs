using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class DrinksController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DrinksController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> drinkList()
		{
			var client = _httpClientFactory.CreateClient();
			var responsemessage = await client.GetAsync("https://localhost:7271/api/Drinks");//apinin adresi
			if (responsemessage.IsSuccessStatusCode)//apinin adresine basariyla gidiyosa
			{
				var jsondata = await responsemessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDrinkDto>>(jsondata);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult addDrink()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> addDrink(CreateDrinkDto dto)
		{
			var client = _httpClientFactory.CreateClient();//client değişkeniyle bir istek oluşturk
			var jsondata = JsonConvert.SerializeObject(dto);//jsondata ile gönderilen metin json formatına dönüştürdü
			StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");//jsondata contente dönüştürüldü üç tane parametresi verildi
			var responseMessage = await client.PostAsync("https://localhost:7271/api/Drinks", content);//ekleme işlemi yapılacak
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("drinkList");
			}
			return View();
		}
		public async Task<IActionResult> deleteDrink(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7271/api/Drinks?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("drinkList");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> updateDrink(int id)
		{
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7271/api/Drinks/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDrinkDto>(jsonData);
                return View(values);
            }
            return View();
            
        }
		[HttpPost]
		public async Task<IActionResult> updateDrink(UpdateDrinkDto updateDrinkDto)
		{
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDrinkDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7271/api/Drinks/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("drinkList");
            }
            return View();
            
        }
	}
}
