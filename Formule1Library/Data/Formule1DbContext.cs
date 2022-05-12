using Microsoft.EntityFrameworkCore;

namespace Formule1Library.Data;

public class Formule1DbContext : DbContext
{
    public Formule1DbContext(DbContextOptions options) : base(options) {}

    public DbSet<Circuit> Circuits { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Grandprix> Grandprixes { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Team> Teams { get; set; }
}