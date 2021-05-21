using Newtonsoft.Json;

namespace Fitverse.Client.Models
{
	public class ReservationGetter
	{
		public int ReservationId { get; set; }
		public int ClassId { get; set; }
		public int MemberId { get; set; }
		public MemberFromCalendar Member { get; set; }
	}
}