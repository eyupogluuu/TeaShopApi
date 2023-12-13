using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.DrinksDto;
using TeaShopApi.DtoLayer.QuestionsDto;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionsController : ControllerBase
	{
		private readonly IQuestionService _questionService;

		public QuestionsController(IQuestionService questionService)
		{
			_questionService = questionService;
		}
		[HttpGet]
		public IActionResult questionsList()
		{
			var values = _questionService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult addQouestion(CreateQuestionDto createQuestionDto )
		{
			Question question = new Question()
			{
				questionDetail=createQuestionDto.questionDetail,
				answerDetail=createQuestionDto.answerDetail
				
			};
			_questionService.TInsert(question);
			return Ok("Yeni Soru-Cevap Başarıyla Eklendi");
		}
		[HttpDelete]
		public IActionResult deleteQuestion(int id)
		{
			var values = _questionService.TGetByID(id);
			_questionService.TDelete(values);
			return Ok("Soru Başarıyla Silindi");
		}
        [HttpGet("{id}")]
        public IActionResult getQuestion(int id)
		{
			var values = _questionService.TGetByID(id);
			return Ok(values);
		}
		[HttpPut]
		public IActionResult updateQuestion(UpdateQuestionDto updateQuestionDto)
		{
			Question que = new Question()
			{
				questionID = updateQuestionDto.QuestionID,
				questionDetail = updateQuestionDto.questionDetails,
				answerDetail = updateQuestionDto.answerDetails
			};
			_questionService.TUpdate(que);
			return Ok("Soru Güncelleme İşlemi Başarılya Gerçekleşti");
		}

	}
}
