using API.Data;
using API.Dtos.Item;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Services.ItemService
{
	public class ItemService : IItemService
	{
		private readonly IMapper _mapper;
		private readonly DataContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ItemService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
			_mapper = mapper;
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}

		private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
			.FindFirstValue(ClaimTypes.NameIdentifier)!);

		public async Task<ServiceResponse<List<GetItemDto>>> GetAllItems()
		{
			var response = new ServiceResponse<List<GetItemDto>>();
			var dbItems = await _context.Items.ToListAsync();
			response.Data = dbItems.Select(c => _mapper.Map<GetItemDto>(c)).ToList();

			return response;
		}

		public async Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto newItem)
		{
			var response = new ServiceResponse<List<GetItemDto>>();
			var item = _mapper.Map<Item>(newItem);
			_context.Items.Add(item);
			await _context.SaveChangesAsync();

			return response;
		}

		public async Task<ServiceResponse<GetItemDto>> GetItem(int id)
		{
			var response = new ServiceResponse<GetItemDto>();
			var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

			if (item is not null)
			{
				response.Data = _mapper.Map<GetItemDto>(item);
			}

			return response;
		}

		public async Task<ServiceResponse<GetItemDto>> UpdateItem(UpdateItemDto updatedItem)
		{
			var response = new ServiceResponse<GetItemDto>();
			var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == updatedItem.Id);

			if (item is not null)
			{
				item.Title = updatedItem.Title;
				item.Description = updatedItem.Description;
				item.Price = updatedItem.Price;

				await _context.SaveChangesAsync();
				response.Data = _mapper.Map<GetItemDto>(item);
			}

			return response;
		}

		public async Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id)
		{
			var response = new ServiceResponse<List<GetItemDto>>();
			var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

			if (item is not null)
			{
				_context.Items.Remove(item);
				await _context.SaveChangesAsync();
				response.Data = await _context.Items.Select(x => _mapper.Map<GetItemDto>(x)).ToListAsync();
			}

			return response;
		}
	}
}
