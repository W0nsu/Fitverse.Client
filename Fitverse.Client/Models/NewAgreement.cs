using System;
using FluentValidation;

namespace Fitverse.Client.Models
{
	public class NewAgreement
	{
		public int MembershipId { get; set; }
		public int MemberId { get; set; }
		public DateTime StartingDate { get; set; }
	}

	public class NewAgreementValidator : AbstractValidator<NewAgreement>
	{
		public NewAgreementValidator()
		{
			RuleFor(x => x.MembershipId)
				.GreaterThan(0)
				.WithMessage("Choose membership");
			
			RuleFor(x => x.StartingDate)
				.NotEmpty()
				.GreaterThanOrEqualTo(DateTime.Now.Date)
				.WithMessage($"Starting date can not be earlier than {DateTime.Now:dd/MM/yyyy}");
		}
	}
}