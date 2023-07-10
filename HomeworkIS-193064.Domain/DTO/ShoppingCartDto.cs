using System;
using HomeworkIS_193064.Domain.Domainmodels;

namespace HomeworkIS_193064.Domain.DTO
{
	public class ShoppingCartDto
	{
		public List<TicketInShoppingCart> Tickets { get; set; }

		public float TotalPrice { get; set; }
        public List<TicketInShoppingCart> TicketInShoppingCart { get; internal set; }
    }
}

