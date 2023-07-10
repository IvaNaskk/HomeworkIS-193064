using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkIS_193064.Domain.Domainmodels
{
	public class TicketInOrder : BaseEntity
	{
		[ForeignKey("TicketId")]
		public int TicketId { get; set; }

		public Ticket Ticket { get; set; }

		[ForeignKey("OrderId")]
		public int OrderId { get; set; }

		public Order Order { get; set; }
	}
}

