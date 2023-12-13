using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult partialHeader()
		{
			return PartialView();
		}
		public PartialViewResult partialSidebar()
		{
			return PartialView();
		}
		public PartialViewResult partialNavbar()
		{
			return PartialView();
		}
		public PartialViewResult partialContent()
		{
			return PartialView();
		}
	}
}
