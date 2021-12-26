using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Angular.ViewModels
{
	public class ContactViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Adress { get; set; }
		public string Email { get; set; }
		public string Category { get; set; }
		public string[] PhoneNumbers { get; set; }
	}
}
