using System.Collections.Generic;
using BusinessController.Models;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System;

namespace BusinessController.DAO
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=Matriz") { }

        public DbSet<PESSOA> Pessoas { get; set; }

        public DbSet<USUARIO> Usuarios { get; set; }

    }
}