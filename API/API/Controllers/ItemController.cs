using API.Dtos.Item;
using API.Models;
using API.Services.ItemService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ItemController : ControllerBase
	{
		private readonly IItemService _itemService;

		public ItemController(IItemService itemService)
        {
			_itemService = itemService;
		}

        [HttpGet("GetAll")]
		public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> GetAllItems()
		{
			return Ok(await _itemService.GetAllItems());
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> AddItem(AddItemDto newItem)
		{
			return Ok(await _itemService.AddItem(newItem));
		}
	}
}
