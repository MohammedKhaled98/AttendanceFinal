#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MohammedKhaled.Models;

namespace MohammedKhaled.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MohammedKhaled.Models.Employee> Employee { get; set; }

        public DbSet<MohammedKhaled.Models.attend> attend { get; set; }
    }
}
