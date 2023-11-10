// 

using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SecretSantaAPI.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {

    }

    // Explicite definition of relationships
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Each Assignment has 1 giver and 1 receiver.
        modelBuilder.Entity<Assignment>()
        .HasOne(a => a.Giver)
        .WithMany()
        .HasForeignKey(a => a.GiverId)
        .OnDelete(DeleteBehavior.Restrict); // prevent cascade delete


        // Configuration for the 'Receiver' relationship in 'Assignment'
        modelBuilder.Entity<Assignment>()
        .HasOne(a => a.Receiver)
        .WithMany()
        .HasForeignKey(a => a.ReceiverId)
        .OnDelete(DeleteBehavior.Restrict); // prevent cascade delete

        // other configurations

        modelBuilder.Entity<UserGroup>()
        .HasKey(ug => new { ug.UserId, ug.GroupId });

        // For each UserGroup entity, there is one associated User. Each User can be associated with many UserGroup entities.
        modelBuilder.Entity<UserGroup>()
        .HasOne(ug => ug.User)
        .WithMany(u => u.UserGroups)
        .HasForeignKey(ug => ug.UserId)
        .OnDelete(DeleteBehavior.Restrict); // prevent cascade delete

        //For each UserGroup entity, there is one associated Group. Each Group can be associated with many UserGroup entities.
        modelBuilder.Entity<UserGroup>()
        .HasOne(ug => ug.Group)
        .WithMany(g => g.UserGroups)
        .HasForeignKey(ug => ug.GroupId)
        .OnDelete(DeleteBehavior.Restrict); // prevent cascade delete

        modelBuilder.Entity<Gift>()
        .HasOne(g => g.User)
        .WithMany(u => u.Gifts)
        .HasForeignKey(g => g.UserId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SecretSantaAPI.Models.Group>()
        .Property(g => g.MaxBudget)
        .HasColumnType("decimal(18, 2)");   // store value as decimal for dollar value.
    }

    // DbSet properties representing the models/tables
    public DbSet<SecretSantaAPI.Models.Group>? Groups { get; set; } // added namespace to avoid collision with system.text
    public DbSet<User>? Users { get; set; }
    public DbSet<Gift>? Gifts { get; set; }
    public DbSet<Assignment>? Assignments { get; set; }

    // add other DbSets here as needed
}