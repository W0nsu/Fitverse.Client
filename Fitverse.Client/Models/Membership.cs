using System;
using FluentValidation;

namespace Fitverse.Client.Models
{
	public class Membership
	{
		public int Id { get; private set; }
		public int MembershipId { get; set; }
		public string Name { get; set; }
		public int PeriodType { get; set; }
		public int Duration { get; set; }
		public int TerminationPeriod { get; set; }
		public float InstallmentPrice { get; set; }
	}
	
	public class MembershipValidator : AbstractValidator<Membership>
	{
		public MembershipValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.MinimumLength(3)
				.MaximumLength(30);
			
			RuleFor(x => x.Duration)
				.NotEmpty()
				.GreaterThan(0);

			RuleFor(x => x.TerminationPeriod)
				.NotEmpty()
				.GreaterThan(0);
			
			RuleFor(x => x.InstallmentPrice)
				.NotEmpty()
				.GreaterThan(0);
		}
	}
}