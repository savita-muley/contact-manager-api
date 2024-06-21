using ContactManagement.API.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ContactManagement.API.DataAccess;
public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DbSet<Contact> Contacts { get; set; }

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("ContactDb");
    }
}