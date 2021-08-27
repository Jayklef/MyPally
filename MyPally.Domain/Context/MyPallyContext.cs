using Microsoft.EntityFrameworkCore;
using MyPally.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPally.Domain.Context
{
    public class MyPallyContext : DbContext
    {
        public MyPallyContext(DbContextOptions<MyPallyContext> options) : base(options)
        {
        }

        public DbSet<Friend> Friends { get; set; }
    }
}