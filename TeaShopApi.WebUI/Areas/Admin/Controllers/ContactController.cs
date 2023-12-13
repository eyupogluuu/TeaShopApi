using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.ContactDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> contactList()
        {
            var client=_httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7271/api/Contact");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();//response mesajdan gelen veriyi string olarak oku yani contact listesini
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsondata);
                return View(values);
            }
            return View();
        }
		[HttpGet]
		public IActionResult addContact()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> addContact(CreateContactDto dto)
		{
			var client = _httpClientFactory.CreateClient();//client değişkeniyle bir istek oluşturk
			var jsondata = JsonConvert.SerializeObject(dto);//jsondata ile gönderilen metin json formatına dönüştürdü
			StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");//jsondata contente dönüştürüldü üç tane parametresi verildi
			var responseMessage = await client.PostAsync("https://localhost:7271/api/Contact", content);//ekleme işlemi yapılacak
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("contactList");
			}
			return View();
		}
        public async Task<IActionResult> deleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7271/api/Contact?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("contactList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> updateContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7271/api/Contact/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
                return View(values);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> updateContact(UpdateContactDto updateContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateContactDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7271/api/Contact/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("contactList");
            }
            return View();

        }
    }
}
