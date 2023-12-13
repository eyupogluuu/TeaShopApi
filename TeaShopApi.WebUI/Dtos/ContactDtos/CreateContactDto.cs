namespace TeaShopApi.WebUI.Dtos.ContactDtos
{
	public class CreateContactDto
	{
		public string messageSenderName { get; set; }
		public string messageSubject { get; set; }
		public string messageMail { get; set; }
		public string messageDetail { get; set; }
		public DateTime messageSendDate { get; set; }
	}
}
