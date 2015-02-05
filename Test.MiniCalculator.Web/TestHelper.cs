using System.Web;
using System.Web.Routing;
using Moq;
using NUnit.Framework;

namespace Test.MiniCalculator.Web
{
    static class TestHelper
    {
        public static void AssertRoute(RouteCollection routes, string url, string controller, string action)
        {
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(url);

            var routeData = routes.GetRouteData(httpContext.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual(controller, routeData.Values["Controller"]);
            Assert.AreEqual(action, routeData.Values["Action"]);
        }
    }
}
