using Microsoft.EntityFrameworkCore;
using ODataWebApi.Models;

namespace ODataWebApi.Context;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions options):base(options) { }
    public DbSet<Category> Categories { get; set; }
        
    
}
