using FakeItEasy;
using DisasterReliefFund;

using Xunit;
using Fluent.Infrastructure.FluentController;
using Fluent.Infrastructure.FluentStartup;
using System.Web.Mvc;

namespace DisasterReliefFund.Tests.Controller
{
    public class AccountControllerTests
    {
        private ApplicationUserManager userManager;
        private ApplicationSignInManager signInManager;

        // Constructor
        public AccountControllerTests()
        {
            // Create fake instances of ApplicationUserManager and ApplicationSignInManager using FakeItEasy
            this.userManager = A.Fake<ApplicationUserManager>();
            this.signInManager = A.Fake<ApplicationSignInManager>();
        }

        [Fact]
        public void AccountController_Index_ReturnsSuccess()
        {
            // Arrange 
            var Controller = new AccountController(this.userManager, this.signInManager);

            // Act 
            var result = Controller.Register();

            // Assert
            Assert.NotNull(result);
           
        }
    }
}
