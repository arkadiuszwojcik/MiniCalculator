using System.Web.Routing;
using NUnit.Framework;
using MiniCalculator.App_Start;

namespace Test.MiniCalculator.Web.App_Start
{
    [TestFixture]
    class TestRouteConfig
    {
        [Test]
        public void Default_route_points_to_Calculator_Index_action()
        {
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            TestHelper.AssertRoute(routes, "~/", "Calculator", "Index");
        }
    }
}
