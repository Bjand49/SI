// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using MigrationTool.MSSQLContext;
using MigrationTool.MYSQLContext;

Console.WriteLine("Hello, World!");
var mssqlDB = new MsSqlDB();

mssqlDB.Database.Migrate();

Console.WriteLine("mssql is migrated!");
var mysqlDB = new MySqlDB();
mysqlDB.Database.Migrate();
Console.WriteLine("mysql is migrated!");

var users = mssqlDB.Users;
mysqlDB.Users.AddRange(users);
mysqlDB.SaveChanges();

Console.WriteLine("transferred users");