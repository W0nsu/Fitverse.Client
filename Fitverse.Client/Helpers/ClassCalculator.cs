using System;
using Fitverse.Client.Models;

namespace Fitverse.Client.Helpers
{
	public class ClassCalculator
	{
		private readonly DateTime _calendarStartingTime;
		private readonly DateTime _calendarEndingTime;

		public ClassCalculator(DateTime calendarStartingTime, DateTime calendarEndingTime)
		{
			_calendarStartingTime = calendarStartingTime;
			_calendarEndingTime = calendarEndingTime;
		}

		public CalendarClassInFrontend ClassTimeToIndexOnCalendar(CalendarClass calendarClass)
		{
			var calendarClassInFronted = new CalendarClassInFrontend();

			var span = calendarClass.StartingTime.TimeOfDay.Subtract(_calendarStartingTime.TimeOfDay);
			var minutesFromCalendarStartingTime = (int)span.TotalMinutes;
			
			calendarClassInFronted.ClassStartingTimeIndex = minutesFromCalendarStartingTime / 15;

			span = calendarClass.EndingTime.TimeOfDay.Subtract(calendarClass.StartingTime.TimeOfDay);
			var classDurationInMinutes = (int) span.TotalMinutes;
			calendarClassInFronted.ClassDurationAsNumberOfIndexes =  classDurationInMinutes / 15;
			if (calendarClassInFronted.ClassDurationAsNumberOfIndexes < 1)
			{
				calendarClassInFronted.ClassDurationAsNumberOfIndexes = 1;
			}

			calendarClassInFronted.ClassDayAsNumber = ExtractDayAsNumber(calendarClass.Date);
			calendarClassInFronted.ClassStartingTimeId =
				$"{calendarClassInFronted.ClassDayAsNumber}-{calendarClassInFronted.ClassStartingTimeIndex}";

			calendarClassInFronted.ClassName = calendarClass.ClassName;
			calendarClassInFronted.ClassStartingTime = calendarClass.StartingTime.ToString("HH:mm");
			calendarClassInFronted.ClassEndingTime = calendarClass.EndingTime.ToString("HH:mm");

			return calendarClassInFronted;
		}

		private static int ExtractDayAsNumber(DateTime date)
		{
			return date.DayOfWeek switch
			{
				DayOfWeek.Sunday => 6,
				DayOfWeek.Monday => 0,
				DayOfWeek.Tuesday => 1,
				DayOfWeek.Wednesday => 2,
				DayOfWeek.Thursday => 3,
				DayOfWeek.Friday => 4,
				DayOfWeek.Saturday => 5,
				_ => throw new ArgumentOutOfRangeException("")
			};
		}
	}
}