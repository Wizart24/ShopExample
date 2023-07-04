using API.Dtos.Item;
using API.Models;

namespace API.Services.ItemService
{
	public interface IItemService
	{
		Task<ServiceResponse<List<GetItemDto>>> GetAllItems();
		Task<ServiceResponse<GetItemDto>> GetItem(int id);
		Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto newItem);
		Task<ServiceResponse<GetItemDto>> UpdateItem(UpdateItemDto updatedItem);
		Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id);
	}
}
