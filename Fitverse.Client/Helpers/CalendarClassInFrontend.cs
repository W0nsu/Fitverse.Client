using System;

namespace Fitverse.Client.Helpers
{
	public class CalendarClassInFrontend
	{
		public string ClassStartingTimeId { get; set; }
		
		public int ClassDayAsNumber { get; set; }
		public int ClassStartingTimeIndex { get; set; }
		public int ClassDurationAsNumberOfIndexes { get; set; }
		public string ClassName { get; set; }
		public string ClassStartingTime { get; set; }
		public string ClassEndingTime { get; set; }
	}
}