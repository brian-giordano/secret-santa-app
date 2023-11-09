// 

using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SecretSantaAPI.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {

    }

    // DbSet properties representing the models/tables
    public DbSet<SecretSantaAPI.Models.Group> Groups { get; set; } // added namespace to avoid collision with system.text
    public DbSet<User> Users { get; set; }
    public DbSet<Gift> Gifts { get; set; }
    public DbSet<Assignment> Assignments { get; set; }

    // add other DbSets here as needed
}