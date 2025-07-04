using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Categories
{
    public class UpdateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/{id}", HandleAsync)
                .WithName("Categories: Update")
                .WithSummary("Atualiza uma categoria")
                .WithDescription("Atualiza uma categoria")
                .WithOrder(2)
                .Produces<Response<Category?>>();

        public static async Task<IResult> HandleAsync(
            ICategoryHandler Handler,
            UpdateCategoryRequest request,
            long id)
        {
            request.UserId = ApiConfiguration.UserId,
            request.Id = id;

            var result = await Handler.UpdateAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
