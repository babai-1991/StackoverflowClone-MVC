using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.DomainModels
{
    public class StackOverflowDbContext:DbContext
    {
        public StackOverflowDbContext():base("StackOverflowDatabaseDbContext")
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
