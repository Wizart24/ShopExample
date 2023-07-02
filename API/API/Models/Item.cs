namespace API.Models
{
	public class Item
	{
        public int Id { get; set; }
        public string Title { get; set; } = "Pen";
        public string Description { get; set; } = "Silver Color";
        public decimal Price { get; set; } = 5;
        public StatusClass Status { get; set; } = StatusClass.InStock;
    }
}
