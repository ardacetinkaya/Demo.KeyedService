using Demo.KeyedService.API;
using Demo.KeyedService.ProductService;


var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ListOptions>("amazon", builder.Configuration.GetSection("ProductService:Amazon")); 
builder.Services.Configure<ListOptions>("cdon", builder.Configuration.GetSection("ProductService:CDON")); 

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddKeyedScoped<IProductService,AmazonProducts>("amazon");
builder.Services.AddKeyedScoped<IProductService,CDONProducts>("cdon");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("/api/v1/")
    .WithTags("Some Fancy API")
    .MapProductsAPI();

app.Run();


