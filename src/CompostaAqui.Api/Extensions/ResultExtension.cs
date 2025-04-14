using CompostaAqui.Application.Models.Result;
using Microsoft.AspNetCore.Mvc;

namespace CompostaAqui.Api.Extensions
{
    public static class ResultExtension
    {
        public static IActionResult Ok<TResult>(this Result<TResult> result) where TResult : class
        {
            return result.IsSuccess ?
                new OkObjectResult(result.Value) :
                result.BadRequest();
        }

        public static IActionResult NoContent(this Result result)
        {
            return result.IsSuccess ?
                new NoContentResult() :
                result.BadRequest();
        }

        public static IActionResult BadRequest<TResult>(this Result<TResult> result) where TResult : class
        {
            return new BadRequestObjectResult(new { result.Errors });
        }

        public static IActionResult BadRequest(this Result result)
        {
            return new BadRequestObjectResult(new { result.Errors });
        }
    }
}
