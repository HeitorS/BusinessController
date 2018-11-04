using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BusinessController.DAO
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=Matriz") { }

    }
}