using System;
using System.Collections.Generic;

namespace Fitverse.Client.Models
{
	public class CalendarClass
	{
		public int ClassId { get; set; }

		public int ClassTypeId { get; set; }

		public DateTime Date { get; set; }

		public DateTime StartingTime { get; set; }

		public DateTime EndingTime { get; set; }

		public string ClassName { get; set; }

		public int Limit { get; set; }

		public string Description { get; set; }

		public int TimetableId { get; set; }

		public List<int> Reservations { get; set; }

		public string ShortDate => Date.ToShortDateString();
	}
}