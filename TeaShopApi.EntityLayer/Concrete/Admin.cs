using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.EntityLayer.Concrete
{
	public class Admin
	{
        public int adminID { get; set; }
        public string username { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
    }
}
