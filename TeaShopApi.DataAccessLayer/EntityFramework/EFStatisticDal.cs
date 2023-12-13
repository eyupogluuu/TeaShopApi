using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Context;

namespace TeaShopApi.DataAccessLayer.EntityFramework
{
    public class EFStatisticDal : IStatisticDal
    {
        private readonly TeaContext _context;

        public EFStatisticDal(TeaContext context)
        {
            _context = context;
        }

        public int ContactCount()
        {
            var values=_context.contacts.Count();
            return values;
        }

        public decimal DrinkAveragePrice()
        {
            var value = 15;
            return value;
            //var avg = _context.drinks.Average(x => x.drinkPrice);
        }

        public int DrinkCount()
        {
            var values = _context.drinks.Count();
            return values;
        }

        public string LastDrinkName()
        {
            var value = _context.drinks.OrderByDescending(x => x.drinkID).Select(Y => Y.drinkName).Take(1).FirstOrDefault();
            return value;
        }

        public string LastQuestion()
        {
            var values = _context.questions.OrderByDescending(x => x.questionID).Select(y => y.questionDetail).FirstOrDefault();
            return values;
        }

        public string LastTestimonialName()
        {
            var values = _context.testimonials.OrderByDescending(x => x.testimonialID).Select(y => y.testimonialName).FirstOrDefault();
            return values;
        }

        public string MaxPriceDrink()
        {
            throw new NotImplementedException();
            //decimal price = _context.drinks.Max(x => x.drinkPrice);
            //var value = _context.drinks.Where(x => x.drinkPrice == price).Select(y => y.drinkName).firsordefault();
        }

        public int QuestionCount()
        {
            var values = _context.questions.Count();
            return values;
        }

        public int TestimonialCount()
        {
            var values = _context.testimonials.Count();
            return values;
        }
    }
}
