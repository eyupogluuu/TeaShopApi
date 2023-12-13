using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.QuestionDto;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class QuestionsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public QuestionsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> questionList()
		{
			var client = _httpClientFactory.CreateClient();
			var responsMessaage = await client.GetAsync("https://localhost:7271/api/Questions");
			if (responsMessaage.IsSuccessStatusCode)
			{
				var jsondata = await responsMessaage.Content.ReadAsStringAsync();//response mesajın içeriğini string olarak oku
				var values = JsonConvert.DeserializeObject<List<ResultQuestionDto>>(jsondata);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult addQuestion()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> addQuestion(CreateQuestionDto createQuestionDto)
		{
			var client= _httpClientFactory.CreateClient();
			var jsondata= JsonConvert.SerializeObject(createQuestionDto);
			StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7271/api/Questions", content);
            if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("questionList");
			}
			return View();
		}
		public async Task<IActionResult> deleteQuestion(int id)
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7271/api/Questions?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("questionList");
			}
			return View();
		}
        [HttpGet]
        public async Task<IActionResult> UpdateQuestion(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7271/api/Questions/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateQuestionDto>(jsonData);//json formatında gelen veriyi view a taşımaya yarar
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateQuestionDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7271/api/Questions/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("questionList");
            }
            return View();

        }
    }
}
