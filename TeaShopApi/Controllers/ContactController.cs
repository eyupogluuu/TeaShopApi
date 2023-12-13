using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.ContactDto;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}
		[HttpGet]
		public IActionResult contactList()
		{
			var values = _contactService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult addContact(CreateContactDto createContactDto)
		{
			Contact con = new Contact()
			{
				messageSenderName = createContactDto.messageSenderName,
				messageSubject = createContactDto.messageSubject,
				messageSendDate = createContactDto.messageSendDate,
				messageDetail = createContactDto.messageDetail,
				messageMail = createContactDto.messageMail,
			};
			_contactService.TInsert(con);
			return Ok("Yeni Mesaj Eklendi");
		}
        [HttpGet("{id}")]
        public ActionResult getContact(int id)
		{
			var values = _contactService.TGetByID(id);
			return Ok(values);
		}
		[HttpDelete]
		public IActionResult deleteContact(int id)
		{
			var values = _contactService.TGetByID(id);
			_contactService.TDelete(values);
			return Ok("Mesaj Silindi");
		}
		[HttpPut]
		public IActionResult updateContact(UpdateContactDto updateContactDto)
		{
			Contact con = new Contact()
			{
				messageSenderName = updateContactDto.messageSenderName,
				messageSubject = updateContactDto.messageSubject,
				messageDetail = updateContactDto.messageDetail,
				messageSendDate = updateContactDto.messageSendDate,
				messageMail = updateContactDto.messageMail,
				contactID = updateContactDto.contactID
			};
			_contactService.TUpdate(con);
			return Ok("Mesaj Güncellendi");
		}
	}
}
