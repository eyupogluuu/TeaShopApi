using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.EntityLayer.Concrete
{
	public class Question
	{
        public int questionID { get; set; }
        public string questionDetail { get; set; }
        public string answerDetail { get; set; }
    }
}
