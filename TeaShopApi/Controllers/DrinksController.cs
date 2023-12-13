using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.DrinksDto;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DrinksController : ControllerBase
	{
		private readonly IDrinkService _drinkService;

		public DrinksController(IDrinkService drinkService)
		{
			_drinkService = drinkService;
		}
		[HttpGet]
		public ActionResult drinkList()
		{
			var values = _drinkService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public ActionResult addDrink(CreateDrinkDto createDrinkDto)
		{
			Drink drink = new Drink()
			{
				drinkImageUrl = createDrinkDto.drinkImageUrl,
				drinkPrice = createDrinkDto.drinkPrice,
				drinkName = createDrinkDto.drinkName
			};
			_drinkService.TInsert(drink);
			return Ok("Yeni İçecek Eklendi");

		}
		[HttpDelete]
		public ActionResult deleteDrink(int id)
		{
			var values=_drinkService.TGetByID(id);
			_drinkService.TDelete(values);
			return Ok("İçecek Silindi");
		}
        //[HttpGet("id")]
		[HttpGet("{id}")]
        public IActionResult getDrink(int id)
		{
			var values=_drinkService.TGetByID(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult updateDrink(UpdateDrinkDto updateDrinkDto)
		{
			Drink drn = new Drink()
			{
				drinkID = updateDrinkDto.drinkID,
				drinkName = updateDrinkDto.drinkName,
				drinkPrice = updateDrinkDto.drinkPrice,
				drinkImageUrl = updateDrinkDto.drinkImageUrl
			};
			_drinkService.TUpdate(drn);
			return Ok("İçecek Bilgileri Güncellendi");
		}
	}
}
