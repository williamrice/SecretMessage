using Microsoft.EntityFrameworkCore;
using webapi.Models;


namespace webapi.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Secret> Secrets { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}