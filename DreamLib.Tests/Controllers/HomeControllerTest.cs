using DreamLib.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DreamLib.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexViewResultIsNotNull()
        {
            //Arrange
            HomeController homeController = new HomeController();

            //Act
            ViewResult viewResult = homeController.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(viewResult);
        }
    }
}
