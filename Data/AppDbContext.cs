using Microsoft.EntityFrameworkCore;
using LoginTemplate_RestAPI.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public required DbSet<User> Users { get; set; }
}