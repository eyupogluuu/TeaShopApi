using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.TestimonialDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class TestimonialsController : Controller
	{
		IHttpClientFactory _httpClientFactory;

		public TestimonialsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> testimonialList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7271/api/Testimonial");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsondata);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult addTestimonial()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> addTestimonial(CreateTestimonialDto createTestimonialDto)
		{
            var client = _httpClientFactory.CreateClient();//client değişkeniyle bir istek oluşturk
            var jsondata = JsonConvert.SerializeObject(createTestimonialDto);//jsondata ile gönderilen metin json formatına dönüştürdü
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");//jsondata contente dönüştürüldü üç tane parametresi verildi
            var responseMessage = await client.PostAsync("https://localhost:7271/api/Testimonial", content);//ekleme işlemi yapılacak
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("testimonialList");
            }
            return View();
        }
        public async Task<IActionResult> deleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7271/api/Testimonial?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("testimonialList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> updateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7271/api/Testimonial/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
                return View(values);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> updateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7271/api/Testimonial/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("testimonialList");
            }
            return View();

        }
    }
}
