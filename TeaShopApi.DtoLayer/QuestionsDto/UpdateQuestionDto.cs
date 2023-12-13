using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DtoLayer.QuestionsDto
{
	public class UpdateQuestionDto
	{
        public int QuestionID { get; set; }
        public string questionDetails { get; set; }
        public string answerDetails { get; set; }
       
    }
}
