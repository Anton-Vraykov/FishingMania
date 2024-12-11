using Moq;
using Microsoft.AspNetCore.Identity;
using FishingMania.Services.Data.Interface_and_services.Admin;


namespace FishingMania.Services.Test
{
    [TestFixture]
    public class UserTests
    {
        private Mock<UserManager<IdentityUser>> mockUserManager;
        private UserService userService;

        [SetUp]
        public void Setup()
        {
            
            mockUserManager = new Mock<UserManager<IdentityUser>>(
                Mock.Of<IUserStore<IdentityUser>>(),
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null);

            userService = new UserService(mockUserManager.Object);
        }
 
        
        [Test]
        public async Task UserExistsByIdAsyncTrue()
        {
            
            var userId = "1";
            var user = new IdentityUser { Id = userId };
            mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            
            var result = await userService.UserExistsByIdAsync(userId);
          
            Assert.IsTrue(result);
        }

        [Test]
        public async Task UserExistsByIdAsyncFalse()
        {
            var userId = "1";
            mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync((IdentityUser)null);

            var result = await userService.UserExistsByIdAsync(userId);

            Assert.IsFalse(result);
        }
        
        [Test]
        public async Task AssignUserToRoleAsyncTrueRoll()
        {
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(false);
            mockUserManager.Setup(um => um.AddToRoleAsync(user, roleName)).ReturnsAsync(IdentityResult.Success);

            var result = await userService.AssignUserToRoleAsync(userId, roleName);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task AssignUserToRoleAsyncRoleFails()
        {
            // Arrange
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(false);
            mockUserManager.Setup(um => um.AddToRoleAsync(user, roleName)).ReturnsAsync(IdentityResult.Failed());

      
            var result = await userService.AssignUserToRoleAsync(userId, roleName);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task AssignUserToRoleAsyncAlreadyInRole()
        {
 
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(true);

            var result = await userService.AssignUserToRoleAsync(userId, roleName);

            Assert.IsTrue(result);
        }        
        [Test]
        public async Task RemoveUserRoleAsyncRoleRemovedSuccessfully()
        {
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(true);
            mockUserManager.Setup(um => um.RemoveFromRoleAsync(user, roleName)).ReturnsAsync(IdentityResult.Success);
 
            var result = await userService.RemoveUserRoleAsync(userId, roleName);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task RemoveUserRoleAsyncRemoveFromRoleFails()
        {
            
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(true);
            mockUserManager.Setup(um => um.RemoveFromRoleAsync(user, roleName)).ReturnsAsync(IdentityResult.Failed());

            var result = await userService.RemoveUserRoleAsync(userId, roleName);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task RemoveUserRoleAsyncUserIsNotInRole()
        {
       
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(false);

            var result = await userService.RemoveUserRoleAsync(userId, roleName);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task DeleteUserAsyncUserIsDeletedSuccessfully()
        {
           
            var userId = "1";
            var user = new IdentityUser { Id = userId };
            mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            mockUserManager.Setup(um => um.DeleteAsync(user)).ReturnsAsync(IdentityResult.Success);

            var result = await userService.DeleteUserAsync(userId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task DeleteUserAsyncDeleteFails()
        {
          
            var userId = "1";
            var user = new IdentityUser { Id = userId };
            mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            mockUserManager.Setup(um => um.DeleteAsync(user)).ReturnsAsync(IdentityResult.Failed());

            var result = await userService.DeleteUserAsync(userId);

            Assert.IsFalse(result);
        }
    }
}