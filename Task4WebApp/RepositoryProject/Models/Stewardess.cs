using System;
using System.ComponentModel.DataAnnotations;

namespace DALProject.Models
{
	public class Stewardess : BaseEntity
	{
		[MaxLength(50)]
		[Required]
		public string Name { get; set; }
		[MaxLength(50)]
		[Required]
		public string Surname { get; set; }
		public DateTime BirthDate { get; set; }
		[Required]
		public int CrewId { get; set; }
	}
}
