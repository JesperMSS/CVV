using System.Data.Entity;

namespace data.Models

{
    public class CVDatabase : DbContext
    {
        public CVDatabase() : base("DefaultConnection")
        {
        }
        public DbSet<CV> cv { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}