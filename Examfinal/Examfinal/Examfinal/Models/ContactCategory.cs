using System.ComponentModel.DataAnnotations;

namespace Exam_Angular.Models
{
	public class ContactCategory
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public Project1.Models.Account Adder { get; set; }
	}
}
