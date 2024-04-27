using Microsoft.EntityFrameworkCore;
using MigrationTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.MSSQLContext
{
    public class MsSqlDB : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=mssqlmigrate;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True");
        }
    }
}
