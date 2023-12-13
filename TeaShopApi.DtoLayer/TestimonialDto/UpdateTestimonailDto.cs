using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DtoLayer.TestimonialDto
{
	public class UpdateTestimonailDto
	{
		public int testimonialID { get; set; }
		public string testimonialName { get; set; }
		public string testimonialComment { get; set; }
		public string testimonialImageUrl { get; set; }
	}
}
