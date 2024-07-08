using Microsoft.EntityFrameworkCore;
using IBUIDING.Models;
using IBUIDING.Models;
using System.Collections.Generic;

namespace IBUIDING.Service
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
    }
}
