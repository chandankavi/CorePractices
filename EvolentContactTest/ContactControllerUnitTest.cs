using Evolent.Models.ContactModel;
using Evolent.Models.Response;
using EvolentContact.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EvolentContactTest
{
    public class ContactControllerUnitTest
    {

        [Fact]
        public async void Test_GetContacts_ReturnTrue()
        {
            var dbContext = DbContextMocker.GetContactDataAccess(nameof(Test_GetContacts_ReturnTrue));
            var controller = new ContactController( dbContext);
            // Add entities in memory
            dbContext.Seed();

            // Act
            var response = await controller.GetContacts();
            //var value = response as IPagedResponse<StockItem>;

            dbContext.Dispose();

            // Assert
            Assert.True(response.isSuccess);
        }

        [Fact]
        public async void Test_DeleteContacts_ReturnTrue()
        {
            var dbContext = DbContextMocker.GetContactDataAccess(nameof(Test_DeleteContacts_ReturnTrue));
            var controller = new ContactController(dbContext);
            // Add entities in memory
            dbContext.Seed();

            // Act
            var response = await controller.DeleteContact(1);
            //var value = response as IPagedResponse<StockItem>;

            dbContext.Dispose();

            // Assert
            Assert.True(response.isSuccess);
        }

        [Fact]
        public async void Test_UpdateContacts_ReturnTrue()
        {
            var dbContext = DbContextMocker.GetContactDataAccess(nameof(Test_UpdateContacts_ReturnTrue));
            var controller = new ContactController(dbContext);
            // Add entities in memory
            dbContext.Seed();

            // Act
            var response = await controller.AddContact(new Contact()
            {
                Id = 1,
                FirstName = "Hugh",
                LastName = "Jackman",
                Email = "HG@gmail.com",
                PhoneNumber = "4545454545",
                Status = Enum.GetName(typeof(Status), Status.Active)
            }) ;
            //var value = response as IPagedResponse<StockItem>;

            dbContext.Dispose();

            // Assert
            Assert.True(response.isSuccess);
        }


    }
}
