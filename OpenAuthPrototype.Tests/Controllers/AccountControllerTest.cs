using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenAuthPrototype;
using OpenAuthPrototype.Controllers;
using System.Web.Mvc;
using OpenAuthPrototype.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace OpenAuthPrototype.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {

        [TestMethod]
        public void LoginRendering()
        {
            // Arrange
            AccountController controller = new AccountController();

            // Act
            ViewResult result = controller.Login("test") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoginShouldFail()
        {
            // Arrange
            AccountController controller = new AccountController();

            //Create a mockup login view model
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "test@test.com";
            loginViewModel.Password = "Test";
            loginViewModel.RememberMe = true;
            // Act
            Task<ActionResult> actionResult = controller.Login(loginViewModel, "testUrl");
            actionResult.Wait();
            // Assert
            Assert.IsNotNull(actionResult);

            Assert.AreEqual(SignInStatus.Failure, actionResult.Status);

        }
    }
}
