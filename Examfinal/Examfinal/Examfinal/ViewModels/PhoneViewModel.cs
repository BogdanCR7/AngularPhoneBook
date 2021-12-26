using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Angular.ViewModels
{
	public class PhoneViewModel
	{
		public string id { get; set; }
		public string PhoneNumber { get; set; }
		public int? ContactId { get; set; }
	}
}
