using Lil.Coustomers.Controllers;
using Lil.Coustomers.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Customers.Tests
{
    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public void GetAsyncResultsOk()
        {
            var customersController = new CustomersController(new CustomersProvider());

            var result = customersController.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncResultsNotFound()
        {
            var customersController = new CustomersController(new CustomersProvider());

            var result = customersController.GetAsync("10000000").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
