using System;
using FluentValidation;

namespace Fitverse.Client.Models
{
	public class ClassType
	{
		public int ClassTypeId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Limit { get; set; }
		public string Room { get; set; }
		public int Duration { get; set; }
	}
	
	public class ClassTypeValidator : AbstractValidator<ClassType>
	{
		public ClassTypeValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.MinimumLength(3)
				.MaximumLength(30);

			RuleFor(x => x.Description)
				.NotEmpty()
				.MinimumLength(3)
				.MaximumLength(255);

			RuleFor(x => x.Limit)
				.NotEmpty()
				.GreaterThan(0);
			
			RuleFor(x => x.Room)
				.NotEmpty()
				.MinimumLength(3)
				.MaximumLength(30);

			RuleFor(x => x.Duration)
				.NotEmpty()
				.GreaterThan(0);
		}
	}
}