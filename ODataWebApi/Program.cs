using Bogus;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ODataWebApi.Context;
using ODataWebApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddOData(opt=>opt.EnableQueryFeatures());
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddOpenApi();
var app = builder.Build();
//minimal api
app.MapGet("seed-data/categoties", async (ApplicationDbContext dbContext) =>
{
    Faker faker = new();

    var categoryNames = faker.Commerce.Categories(100);
    List<Category> categories = categoryNames.Select(s => new Category
    {
        Name = s,
    }).ToList();
    dbContext.AddRange(categories);

    await dbContext.SaveChangesAsync();

    return Results.NoContent();
}).Produces(204).WithTags("SeedCategories");
app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();
app.Run();
