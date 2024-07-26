using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccessLayer.Context
{
    public class TopicContext : DbContext
    {
        //Migration işlemlerini yaparken buradan tablo adlarını veriyoruz 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JBL3A9M\\SQLEXPRESS;database=MyAcademyTopicDb;integrated security=true;trustServerCertificate=true");
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manuel> Manuels { get; set; }
        public DbSet<Questions> Questionss  { get; set; }

    }
}
