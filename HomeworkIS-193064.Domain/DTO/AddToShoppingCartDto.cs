using System;
using HomeworkIS_193064.Domain.Domainmodels;

namespace HomeworkIS_193064.Domain.DTO
{
	public class AddToShoppingCartDto
	{
		public Ticket SelectedTicket { get; set; }
		public int TicketId { get; set; }
		public int Quantity { get; set; }
	}
}
