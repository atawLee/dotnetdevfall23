namespace mesWeb.Entity;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public DbSet<WorkOrder> WorkOrders { get; set; }
    public DbSet<Manufacture> Manufactures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=MES;User ID=root;Password=dlwhdgns;CharSet=utf8mb4", new MySqlServerVersion(new Version(8, 1,0 )));
    }
}
