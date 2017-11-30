using NewTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewTask
{
    public class MyDbContext:DbContext
    {
       public  MyDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<User_assign_project> user_assigend_projects { get; set; }
        public DbSet<Tasktbl> task_tables { get; set; }
        public DbSet<Commenttbl> comments { get; set; }
        public DbSet<Role> roles { get; set; }
       






    }
}