using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exam_Angular.Models
{
	public class Contact
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public string Email { get; set; }
		public string Adress { get; set; }
		public ContactCategory Category { get; set; }
		public List<Phone> Phones { get; set; } = new List<Phone>();
		public Project1.Models.Account Adder { get; set; }
	}
}
