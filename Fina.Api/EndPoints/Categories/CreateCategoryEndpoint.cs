﻿using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;

namespace Fina.Api.EndPoints.Categories
{
    public class CreateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
             .WithName("Categories: Create")
            .WithSummary("Criar uma nova categoria")
            .WithDescription("Cria uma nova categoria")
            .WithOrder(1)
            .Produces<Response<Category?>>();
        private static async Task<IResult> HandleAsync(
            ICategoryHandler handler,
            CreateCategoryRequest request)
        {
            request.UserId = Api.ApiConfiguration.UserId;
            var response = await handler.CreateAsync(request);
            return response.IsSuccess
                ? TypedResults.Created($"v1/Categories/{response.Data?.Id}",response)
                : TypedResults.BadRequest(response);
        }
    }
}
