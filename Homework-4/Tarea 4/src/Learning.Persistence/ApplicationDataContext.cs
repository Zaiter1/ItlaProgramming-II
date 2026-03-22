using Microsoft.EntityFrameworkCore;
using LearningApi.Domain.Entities;

namespace LearningApi.Persistence
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }


        //Miguel Zaiter 2025-0928
    }
}

