using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.ContactDtos;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _ContactComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ContactComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpPost]
        public async Task<IViewComponentResult> InvokeAsync(CreateContactDto createContactDto)
        {
			var client = _httpClientFactory.CreateClient();//client değişkeniyle bir istek oluşturk
			var jsondata = JsonConvert.SerializeObject(createContactDto);//jsondata ile gönderilen metin json formatına dönüştürdü
			StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");//jsondata contente dönüştürüldü üç tane parametresi verildi
			var responseMessage = await client.PostAsync("https://localhost:7271/api/Contact", content);//ekleme işlemi yapılacak
			
			return View();
		}
        
    }
}
