using API.Models;

namespace API.Dtos.Item
{
	public class AddItemDto
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; } = 25;
		public StatusClass Status { get; set; } = StatusClass.InStock;
	}
}
