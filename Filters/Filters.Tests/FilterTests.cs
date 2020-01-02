using Filters.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;
using System.Linq;
using Xunit;

namespace Filters.Tests
{
    public class FilterTests
    {
        [Fact]
        public void TestHttpsFilter()
        {
            //Przygotowanie
            var httpsRequest = new Mock<HttpRequest>();
            httpsRequest.SetupSequence(m => m.IsHttps).Returns(true).Returns(false);

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(m => m.Request).Returns(httpsRequest.Object);

            var actionContext = new ActionContext(httpContext.Object, new Microsoft.AspNetCore.Routing.RouteData(), new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());

            var authContext = new Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext(actionContext, Enumerable.Empty<IFilterMetadata>().ToList());

            HttpsOnlyAttribute filter = new HttpsOnlyAttribute();

            //Dzia³anie i asercje
            filter.OnAuthorization(authContext);
            Assert.Null(authContext.Result);

            filter.OnAuthorization(authContext);
            Assert.IsType(typeof(StatusCodeResult), authContext.Result);
            Assert.Equal(StatusCodes.Status403Forbidden, (authContext.Result as StatusCodeResult).StatusCode);

        }
    }
}
