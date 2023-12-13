using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.ViewComponents
{
	public class _UIStatisticComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _UIStatisticComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			var responsemessage2 = await client.GetAsync("https://localhost:7271/api/Statistic/GetDrinkCount");//apinin adresi
			var jsondata2 = await responsemessage2.Content.ReadAsStringAsync();
			ViewBag.v2 = jsondata2;

			var responsemessage8 = await client.GetAsync("https://localhost:7271/api/Statistic/GetTestimonialCount");//apinin adresi
			var jsondata8 = await responsemessage8.Content.ReadAsStringAsync();
			ViewBag.v8 = jsondata8;

			var responsemessage1 = await client.GetAsync("https://localhost:7271/api/Statistic/GetDrinkAvaragePrice");//apinin adresi
			var jsondata1 = await responsemessage1.Content.ReadAsStringAsync();
			ViewBag.v1 = jsondata1;

			var responsemessage4 = await client.GetAsync("https://localhost:7271/api/Statistic/GetContactCount");//apinin adresi
			var jsondata4 = await responsemessage4.Content.ReadAsStringAsync();
			ViewBag.v4 = jsondata4;
			return View();
		}
	}
}
