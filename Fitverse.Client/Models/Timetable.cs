using System;
using FluentValidation;

namespace Fitverse.Client.Models
{
	public class Timetable
	{
		public int TimetableId { get; set; }
		public int ClassTypeId { get; set; }
		
		public string ClassTypeName { get; set; }
		public DateTime StartingDate { get; set; }
		public DateTime EndingDate { get; set; }
		public DateTime ClassesStartingTime { get; set; }
		public int PeriodType { get; set; }
	}

	public class TimetableValidator : AbstractValidator<Timetable>
	{
		public TimetableValidator()
		{
			RuleFor(x => x.ClassTypeId)
				.GreaterThan(0)
				.WithMessage("Choose class type");

			RuleFor(x => x.StartingDate)
				.NotEmpty()
				.GreaterThan(DateTime.Now.Date)
				.WithMessage($"Starting date can not be earlier than {DateTime.Now.AddDays(1):dd/MM/yyyy}");
			
			RuleFor(x => x.EndingDate)
				.NotEmpty()
				.GreaterThanOrEqualTo(x => x.StartingDate)
				.WithMessage($"Ending date can not be earlier than starting date");
		}
	}
}