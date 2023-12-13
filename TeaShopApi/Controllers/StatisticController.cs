using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }
        [HttpGet("GetDrinkAvaragePrice")]
        public IActionResult GetDrinkAvaragePrice()
        {
            return Ok(_statisticService.TDrinkAveragePrice());
        }
        [HttpGet("GetDrinkCount")]
        public IActionResult GetDrinkCount()
        {
            return Ok(_statisticService.TDrinkCount());
        }
        [HttpGet("GetLastDrinkName")]
        public IActionResult GetLastDrinkName()
        {
            return Ok(_statisticService.TLastDrinkName());
        }
        [HttpGet("GetContactCount")]
        public IActionResult GetContactCount()
        {
            return Ok(_statisticService.TContactCount());
        }
        [HttpGet("GetLastQuestion")]
        public IActionResult GetLastQuestion()
        {
            return Ok(_statisticService.TLastQuestion());
        }
        [HttpGet("GetLastTestimonialName")]
        public IActionResult GetLastTestimonialName()
        {
            return Ok(_statisticService.TLastTestimonialName());
        }
        [HttpGet("GetQuestionCount")]
        public IActionResult GetQuestionCount()
        {
            return Ok(_statisticService.TQuestionCount());
        }
        [HttpGet("GetTestimonialCount")]
        public IActionResult GetTestimonialCount()
        {
            return Ok(_statisticService.TTestimonialCount());
        }
    }
}
