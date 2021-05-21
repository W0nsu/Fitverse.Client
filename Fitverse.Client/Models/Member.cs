using System;
using Fitverse.Client.Helpers;
using FluentValidation;

namespace Fitverse.Client.Models
{
	public class Member
	{
		public int MemberId { get; set; }
		public string Name { get; set; }
		public string SurName { get; set; }
		public DateTime BirthDate { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Pesel { get; set; }
	}

	public class MemberValidator : AbstractValidator<Member>
	{
		public MemberValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Name must not be empty");

			RuleFor(x => x.SurName)
				.NotEmpty()
				.WithMessage("Surname must not be empty");

			RuleFor(x => x.Email)
				.NotEmpty()
				.WithMessage("Email must not be empty");

			RuleFor(x => x.Email)
				.EmailAddress()
				.WithMessage("Email format: example@domain.com");

			RuleFor(x => x.PhoneNumber)
				.Matches(
					"^\\d{9}$")
				.WithMessage("Phone number mush have 9 numbers");
			;

			RuleFor(x => x.Pesel)
				.NotEmpty()
				.WithMessage("Pesel must not be empty");

			RuleFor(x => x.Pesel)
				.Matches("^\\d{11}$")
				.WithMessage("Pesel must have 11 numbers");

			RuleFor(x => x.Pesel)
				.Must(ValidatePesel)
				.WithMessage("Pesel invalid");
		}

		private bool ValidatePesel(string pesel)
		{
			if (pesel is null)
				return false;

			try
			{
				var birthDay = new BirthDayDate
				{
					Year = int.Parse(pesel.Substring(0, 2)),
					Month = int.Parse(pesel.Substring(2, 2)),
					Day = int.Parse(pesel.Substring(4, 2))
				};
				
				return birthDay.Month > 0 && birthDay.Month <= 12 && birthDay.Day > 0 && birthDay.Day <= 31;
			}
			catch
			{
				return false;
			}
		}
	}
}