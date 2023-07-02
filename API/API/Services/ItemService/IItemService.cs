using API.Dtos.Item;
using API.Models;

namespace API.Services.ItemService
{
	public interface IItemService
	{
		Task<ServiceResponse<List<GetItemDto>>> GetAllItems();
		Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto newItem);
	}
}
