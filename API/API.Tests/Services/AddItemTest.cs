using API.Data;
using API.Dtos.Item;
using API.Models;
using API.Services.ItemService;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Tests.Services
{
	[TestClass]
	public class AddItemTest
	{
		private Mock<IMapper> _mapperMock;
		private Mock<DbSet<Item>> _itemsDbSetMock;
		private DataContext _context;
		private Mock<IHttpContextAccessor> _httpContextAccessorMock;
		private ItemService _itemService;

		[TestInitialize]
		public void Setup()
		{
			_mapperMock = new Mock<IMapper>();
			_itemsDbSetMock = new Mock<DbSet<Item>>();
			_httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var options = new DbContextOptionsBuilder<DataContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;
			_context = new DataContext(options);

			_itemService = new ItemService(
				_mapperMock.Object,
				_context,
				_httpContextAccessorMock.Object
			);
		}

		[TestMethod]
		public async Task AddItem_AddsNewItem_ReturnsServiceResponse()
		{
			// Arrange
			var newItem = new AddItemDto { 
				Title = "Bible",
				Description = "Old Book",
				Price = 25M,
				Status = StatusClass.InStock
			};
			var newItemModel = new Item {
				Id = 1,
				Title = "Bible",
				Description = "Old Book",
				Price = 25M,
				Status = StatusClass.InStock
			};

			_mapperMock.Setup(m => m.Map<Item>(It.IsAny<AddItemDto>())).Returns(newItemModel);

			// Act
			var result = await _itemService.AddItem(newItem);

			// Assert
			_mapperMock.Verify(m => m.Map<Item>(It.IsAny<AddItemDto>()), Times.Once);
			Assert.IsTrue(_context.Items.Any(i => i == newItemModel));
		}
	}
}
