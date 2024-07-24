using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScholarsHub.Models;

namespace ScholarsHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
