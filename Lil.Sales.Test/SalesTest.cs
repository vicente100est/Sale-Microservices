using Lil.Sales.Controllers;
using Lil.Sales.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Sales.Test
{
    [TestClass]
    public class SalesTest
    {
        [TestMethod]
        public void GetAsyncResultsOk()
        {
            var salesController = new SalesController(new SalerProvider());
            var result = salesController.GetAsync("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncResultsError()
        {
            var salesController = new SalesController(new SalerProvider());
            var results = salesController.GetAsync("100000000").Result;

            Assert.IsNotNull(results);
            Assert.IsInstanceOfType(results, typeof(NotFoundResult));
        }
    }
}
