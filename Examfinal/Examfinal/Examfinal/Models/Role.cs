using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string role { get; set; }

        public List<Account> accounts { get; set; }
    }
}
