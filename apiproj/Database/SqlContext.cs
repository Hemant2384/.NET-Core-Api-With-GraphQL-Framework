using System;
using Microsoft.EntityFrameworkCore;
using apiproj.Models;
using System.Collections.Generic;

namespace apiproj.Database
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<SqlMovie> SqlMovie { get; set; }
    }
}