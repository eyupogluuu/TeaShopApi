using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Abstract;

namespace TeaShopApi.BusinessLayer.Concrete
{
    public class StatisticManager : IStatisticService
    {
        private readonly IStatisticDal _statisticDal;
        public StatisticManager(IStatisticDal statisticDal)
        {
            _statisticDal = statisticDal;
        }

        public int TContactCount()
        {
            return _statisticDal.ContactCount();
        }

        public decimal TDrinkAveragePrice()
        {
            return _statisticDal.DrinkAveragePrice();
        }

        public int TDrinkCount()
        {
            return _statisticDal.DrinkCount();
        }

        public string TLastDrinkName()
        {
            return _statisticDal.LastDrinkName();
        }

        public string TLastQuestion()
        {
            return _statisticDal.LastQuestion();
        }

        public string TLastTestimonialName()
        {
            return _statisticDal.LastTestimonialName();
        }

        public string TMaxPriceDrink()
        {
            return _statisticDal.MaxPriceDrink();
        }

        public int TQuestionCount()
        {
            return _statisticDal.QuestionCount();
        }

        public int TTestimonialCount()
        {
            return _statisticDal.TestimonialCount();
        }
    }
}
