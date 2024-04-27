using Microsoft.EntityFrameworkCore;
using MigrationTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.MYSQLContext
{
    public class MySqlDB : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;port=3307;uid=root;pwd=12345;database=mysqlmigration");
        }

    }
}
