using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataWebApi.Context;
using ODataWebApi.Models;
namespace ODataWebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public sealed class MyTestsController(ApplicationDbContext context) : ControllerBase
{
  
    [HttpGet]
    [EnableQuery]
    public IQueryable<Category> Categories()
    {
        var categories=context.Categories.AsQueryable();
        return categories;
    }
}


