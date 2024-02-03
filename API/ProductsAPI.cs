
using Demo.KeyedService.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Demo.KeyedService.API;

public static class ProductsAPI
{
    public static IEndpointRouteBuilder MapProductsAPI(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products", GetProducts);
        app.MapGet("/products/alternatives", GetAlternativeProducts);
        return app;
    }

    public static async Task<ActionResult<List<string>>> GetProducts([FromKeyedServices("amazon")] IProductService service, IOptionsSnapshot<ListOptions> config)
    {
        var listOptions = config.Get("amazon");
        return service.ListProducts(listOptions.ListCount);
    }

    public static async Task<ActionResult<List<string>>> GetAlternativeProducts([FromKeyedServices("cdon")] IProductService service, IOptionsSnapshot<ListOptions> config)
    {
        var listOptions = config.Get("cdon");
        return service.ListProducts(listOptions.ListCount);
    }

}