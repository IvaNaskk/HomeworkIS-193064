using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkIS_193064.Domain.Domainmodels
{
	public class TicketInShoppingCart : BaseEntity
	{
		public int TicketId { get; set; }

		public int ShoppingCartId { get; set; }

		[ForeignKey("TicketId")]
		public Ticket Ticket { get; set; }

		[ForeignKey("ShoppingCartId")]
		public ShoppingCart ShoppingCart { get; set; }

		public int Quantity { get; set; }
	}
}

