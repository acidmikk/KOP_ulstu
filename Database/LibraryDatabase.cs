using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    internal class LibraryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=DatabasePizzeria;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Book> Books { set; get; }
        public virtual DbSet<Author> Authors{ set; get; }
    }
}
