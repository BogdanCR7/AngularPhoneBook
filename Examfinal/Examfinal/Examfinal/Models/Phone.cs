using System.ComponentModel.DataAnnotations;

namespace Exam_Angular.Models
{
	public class Phone
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
	}
}
