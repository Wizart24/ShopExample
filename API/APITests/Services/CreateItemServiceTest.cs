using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace APITests.Services
{
	[TestClass]
	public class CreateItemServiceTest
	{
		[TestMethod]
		public async Task ResultofCallValuesFromServiceResult()
		{
			//Arrange
			var mockedItemsRepository = new Mock<CreateItemServiceTest>();
			var createItemService = new CreateItemServiceTest(mockedItemsRepository.Object);
			var createItem = new AddItemDto(
				
			)

			//Act


			//Assert
		}
	}
}
