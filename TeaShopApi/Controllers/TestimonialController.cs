using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.TestimonialDto;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{ 
		private readonly ITestimonialService _testimonialService;

		public TestimonialController(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}
		[HttpGet]
		public IActionResult testimonialList() {
			var values = _testimonialService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult addTestimonial( CreateTestimonialDto createTestimonialDto)
		{
			Testimonial testimonial = new Testimonial()
			{
				testimonialName = createTestimonialDto.testimonialName,
				testimonialComment = createTestimonialDto.testimonialComment,
				testimonialImageUrl = createTestimonialDto.testimonialImageUrl
			};
			_testimonialService.TInsert(testimonial);
			return Ok("Yeni Referans Başarıyla Eklendi");
		}
        [HttpGet("{id}")]
        public IActionResult getTestimonial(int id)
		{
			var values=_testimonialService.TGetByID(id);
			return Ok(values);
		}
		[HttpDelete]
		public IActionResult deleteTestimonail(int id)
		{
			var values = _testimonialService.TGetByID(id);
			_testimonialService.TDelete(values);
			return Ok("Referans Silme İşlemi Gerçekleşti");
		}
		[HttpPut]
		public IActionResult updateTestimonial(UpdateTestimonailDto updateTestimonailDto)
		{
			Testimonial testi = new Testimonial()
			{
				testimonialID = updateTestimonailDto.testimonialID,
				testimonialName = updateTestimonailDto.testimonialName,
				testimonialComment = updateTestimonailDto.testimonialComment,
				testimonialImageUrl = updateTestimonailDto.testimonialImageUrl
			};
			_testimonialService.TUpdate(testi);
			return Ok("Referans Güncelleme İşlemi Başarıyla Gerçekleşti");

		}
	}
}
