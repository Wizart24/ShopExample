using API.Dtos.Item;
using API.Models;
using API.Services.ItemService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Authorize]
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

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceResponse<GetItemDto>>> GetItem(int id)
		{
			return Ok(await _itemService.GetItem(id));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> AddItem(AddItemDto newItem)
		{
			return Ok(await _itemService.AddItem(newItem));
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<GetItemDto>>> UpdateItem(UpdateItemDto updateItem)
		{
			return Ok(await _itemService.UpdateItem(updateItem));
		}

		[HttpDelete]
		public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> DeleteItem(int id)
		{
			return Ok(await _itemService.DeleteItem(id));
		}
	}
}
