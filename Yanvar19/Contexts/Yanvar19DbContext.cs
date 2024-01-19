using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Yanvar19.Models;

namespace Yanvar19.Contexts
{
    public class Yanvar19DbContext:IdentityDbContext
    {
        public Yanvar19DbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Instructors> Instructors { get; set; }
    }
}
