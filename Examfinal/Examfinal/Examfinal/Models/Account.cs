using Exam_Angular.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();

        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public List<ContactCategory> categories { get; set; } = new List<ContactCategory>();

        public List<Phone> phones  { get; set; } = new List<Phone>();


    }
    

   
}
