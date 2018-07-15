using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALProject.Models
{
	public class Pilot: BaseEntity
	{
		public string Name { get; set; }
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
