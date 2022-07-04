
using Microsoft.EntityFrameworkCore;
using Wegot.MyLibrary.Api.ApplicationCore.Entities;

namespace WeGot.MyLibrary.Api.Infrastructure.Data
{
    public class MyLibraryDbContext : DbContext
    {

        public DbSet<Book> Books { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             
        }
        public MyLibraryDbContext(DbContextOptions<MyLibraryDbContext> options) : base(options)
        {

        }

    }
}
