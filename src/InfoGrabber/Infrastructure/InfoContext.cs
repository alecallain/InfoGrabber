using Microsoft.EntityFrameworkCore;

namespace InfoGrabber.Infrastructure;

public class InfoContext : DbContext
{
    public DbSet<Main> Main { get; set; }
    
    public DbSet<Setup> Setup { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}

public class Main
{
    
}

public class Setup
{
    
}