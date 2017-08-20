using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminSecurityTests
    {
        [TestMethod]
        public void Can_Login_With_Valid_Credentials()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.authenticate("admin", "secret")).Returns(true);

            LoginViewModel model = new LoginViewModel()
            {
                Username = "admin",
                Password = "secret"
            };

            AccountController target = new AccountController(mock.Object);

            var result = target.Login(model, "/MyUrl");

            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("/MyUrl", ((RedirectResult)result).Url);
        }

        [TestMethod]
        public void Cannot_Login_With_Invalid_Credentials()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.authenticate("baduser", "badpass")).Returns(false);

            LoginViewModel model = new LoginViewModel()
            {
                Username = "baduser",
                Password = "badpass"
            };

            AccountController target = new AccountController(mock.Object);

            var result = target.Login(model, "/MyUrl");

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}
