using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALProject.Models
{
	public class Pilot: BaseEntity
	{
		[MaxLength(50)]
		[Required]
		public string Name { get; set; }
		[MaxLength(50)]
		[Required]
		public string Surname { get; set; }
		public DateTime BirthDate { get; set; }
		public long TimeTicks { get; set; }
		[NotMapped]
		public TimeSpan Experience
		{
			get
			{
				return new TimeSpan(TimeTicks);
			}
			set
			{
				TimeTicks = value.Ticks;
			}
		}

	}
}
