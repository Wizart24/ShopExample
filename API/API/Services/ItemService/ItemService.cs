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
	}
}
