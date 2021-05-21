namespace Fitverse.Client.Models
{
	public class OverdueInstallment
	{
		public string MemberFirstName { get; set; }
		
		public string MemberSurname { get; set; }

		public string MembershipName { get; set; }

		public Installment InstallmentDetails { get; set; }
	}
}