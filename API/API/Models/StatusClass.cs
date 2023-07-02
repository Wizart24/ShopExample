using System.Text.Json.Serialization;

namespace API.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum StatusClass
	{
		Sold = 1,
		InStock = 2
	}
}
