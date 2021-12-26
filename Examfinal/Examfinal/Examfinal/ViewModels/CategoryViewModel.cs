using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Angular.ViewModels
{
	public class CategoryViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ContactsCount { get; set; }
	}
}
