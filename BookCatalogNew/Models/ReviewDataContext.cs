using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogNew.Models
{
    public class ReviewDataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public ReviewDataContext(DbContextOptions<ReviewDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
