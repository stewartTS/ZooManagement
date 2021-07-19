using Microsoft.EntityFrameworkCore;
using System;
using ZooManagement.Models.Database;

namespace ZooManagement
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
    }
}
