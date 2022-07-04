
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wegot.MyLibrary.Api.ApplicationCore.Entities;

namespace WeGot.MyLibrary.Api.Infrastructure.Data
{
    public class MyLibraryDbContext : DbContext
    {
       
        public System.Data.Entity.DbSet<Book> Book { get; set; }

        public MyLibraryDbContext(DbContextOptions<MyLibraryDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             
        }

    }
}
