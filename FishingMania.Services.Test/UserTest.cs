using Moq;
using Microsoft.AspNetCore.Identity;
using FishingMania.Services.Data.Interface_and_services.Admin;


namespace FishingMania.Services.Test
{
    [TestFixture]
    public class UserTests
    {
        private Mock<UserManager<IdentityUser>> _mockUserManager;
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            
            _mockUserManager = new Mock<UserManager<IdentityUser>>(
                Mock.Of<IUserStore<IdentityUser>>(),
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null);

            _userService = new UserService(_mockUserManager.Object);
        }
 
        
        [Test]
        public async Task UserExistsByIdAsyncTrue()
        {
            
            var userId = "1";
            var user = new IdentityUser { Id = userId };
            _mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            
            var result = await _userService.UserExistsByIdAsync(userId);
          
            Assert.IsTrue(result);
        }

        [Test]
        public async Task UserExistsByIdAsyncFalse()
        {
            var userId = "1";
            _mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync((IdentityUser)null);

            var result = await _userService.UserExistsByIdAsync(userId);

            Assert.IsFalse(result);
        }
        
        [Test]
        public async Task AssignUserToRoleAsyncTrueRoll()
        {
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            _mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(false);
            _mockUserManager.Setup(um => um.AddToRoleAsync(user, roleName)).ReturnsAsync(IdentityResult.Success);

            var result = await _userService.AssignUserToRoleAsync(userId, roleName);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task AssignUserToRoleAsyncRoleFails()
        {
            // Arrange
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            _mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(false);
            _mockUserManager.Setup(um => um.AddToRoleAsync(user, roleName)).ReturnsAsync(IdentityResult.Failed());

      
            var result = await _userService.AssignUserToRoleAsync(userId, roleName);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task AssignUserToRoleAsyncAlreadyInRole()
        {
 
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            _mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(true);

            var result = await _userService.AssignUserToRoleAsync(userId, roleName);

            Assert.IsTrue(result);
        }        
        [Test]
        public async Task RemoveUserRoleAsyncRoleRemovedSuccessfully()
        {
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            _mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(true);
            _mockUserManager.Setup(um => um.RemoveFromRoleAsync(user, roleName)).ReturnsAsync(IdentityResult.Success);
 
            var result = await _userService.RemoveUserRoleAsync(userId, roleName);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task RemoveUserRoleAsyncRemoveFromRoleFails()
        {
            
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            _mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(true);
            _mockUserManager.Setup(um => um.RemoveFromRoleAsync(user, roleName)).ReturnsAsync(IdentityResult.Failed());

            var result = await _userService.RemoveUserRoleAsync(userId, roleName);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task RemoveUserRoleAsyncUserIsNotInRole()
        {
       
            var userId = "1";
            var roleName = "Admin";
            var user = new IdentityUser { Id = userId };
            _mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.IsInRoleAsync(user, roleName)).ReturnsAsync(false);

            var result = await _userService.RemoveUserRoleAsync(userId, roleName);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task DeleteUserAsyncUserIsDeletedSuccessfully()
        {
           
            var userId = "1";
            var user = new IdentityUser { Id = userId };
            _mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.DeleteAsync(user)).ReturnsAsync(IdentityResult.Success);

            var result = await _userService.DeleteUserAsync(userId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task DeleteUserAsyncDeleteFails()
        {
          
            var userId = "1";
            var user = new IdentityUser { Id = userId };
            _mockUserManager.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.DeleteAsync(user)).ReturnsAsync(IdentityResult.Failed());

            var result = await _userService.DeleteUserAsync(userId);

            Assert.IsFalse(result);
        }
    }
}