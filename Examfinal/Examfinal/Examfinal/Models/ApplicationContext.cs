using Exam_Angular.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Account> accounts { get; set; }
        public DbSet<Role> roles { get; set; }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactCategory> ContactCategory { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}

