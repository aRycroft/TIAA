using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.UnitTests.Controllers
{
    public static class ControllerTestMethods
    {
        public static void AssertResponseCodeIsExpected<StatusCode>(IActionResult? result)
            where StatusCode : IActionResult
        {
            Assert.IsAssignableFrom<StatusCode>(result);
        }

        public static void AssertResponseCodeAndTypeIsExpected<StatusResult, ExpectedObjectType>(IActionResult? result)
            where StatusResult : ObjectResult
            where ExpectedObjectType : class
        {
            Assert.NotNull(result);
            AssertResponseCodeIsExpected<StatusResult>(result);
            Assert.IsAssignableFrom<StatusResult>(result);
            var httpResult = result as StatusResult;
            Assert.NotNull(httpResult);
            Assert.NotNull(httpResult?.Value);
            Assert.IsAssignableFrom<ExpectedObjectType>(httpResult?.Value);
        }

        public static async Task AssertControllerMethodReturnsExpectedAndCallsService<ExpectedHttpCode>(Func<Task<IActionResult>> controllerAction, Action postExecuteAction)
            where ExpectedHttpCode : IActionResult
        {
            var result = await controllerAction.Invoke();
            AssertResponseCodeIsExpected<ExpectedHttpCode>(result);
            postExecuteAction();
        }

        public static async Task AssertControllerMethodReturnsExpectedAndCallsService<ExpectedHttpCode, ExpectedObject>(Func<Task<IActionResult>> controllerAction, Action postExecuteAction)
            where ExpectedObject : class
            where ExpectedHttpCode : ObjectResult
        {
            var result = await controllerAction.Invoke();
            AssertResponseCodeAndTypeIsExpected<ExpectedHttpCode, ExpectedObject>(result);
            postExecuteAction();
        }
    }
}
