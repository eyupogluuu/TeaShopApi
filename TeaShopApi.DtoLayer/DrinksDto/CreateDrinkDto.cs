using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DtoLayer.DrinksDto
{
	public class CreateDrinkDto
	{
        public string drinkName { get; set; }
        public string drinkPrice { get; set; }
        public string drinkImageUrl { get; set; }
    }
}
