using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZooManagement.Models.Database;

namespace ZooManagement
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) { }

        public DbSet<AnimalDbModel> Animals { get; set; }
        public DbSet<AnimalTypeDbModel> AnimalType { get; set; }
        public IEnumerable<object> Animal { get; internal set; }
    }
}
