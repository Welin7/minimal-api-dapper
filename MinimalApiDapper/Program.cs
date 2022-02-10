using Microsoft.AspNetCore.Mvc;
using MinimalApiDapper.Interfaces;
using MinimalApiDapper.Models;
using MinimalApiDapper.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IProductRepository, ProductRepository>();

var app = builder.Build();

app.MapGet("/v1/products", ([FromServices] IProductRepository productRepository) =>
{
    return productRepository.GetProducts();
});

app.MapPost("/v1/product", ([FromServices] IProductRepository productRepository, Product product) =>
{
    var result = productRepository.Add(product);
    return (result ? Results.Ok($"Product {product.Name} created sucess!"):Results.BadRequest("Could not possible create product!"));
});

app.MapPut("/v1/product", ([FromServices] IProductRepository productRepository, string name, int id) =>
{
    var result = productRepository.Update(name, id);
    return (result ? Results.Ok($"Product name changed sucess!") : Results.BadRequest("Could not possible change product name!"));
});

app.MapDelete("/v1/product", ([FromServices] IProductRepository productRepository, int id) =>
{
    var result = productRepository.Delete(id);
    return (result ? Results.Ok($"Product deleted with sucess!") : Results.BadRequest("Could not possible delete the product!"));
});

app.MapGet("/v1/product", ([FromServices] IProductRepository productRepository, int id) =>
{
    return productRepository.GetById(id);
});
app.Run();
