namespace API.Dtos.Item
{
	public class UpdateItemDto
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; } = 25;
	}
}
