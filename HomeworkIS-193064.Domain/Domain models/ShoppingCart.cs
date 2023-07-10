using System;
using System.ComponentModel.DataAnnotations;

namespace HomeworkIS_193064.Domain.Domainmodels
{
	public class ShoppingCart : BaseEntity
    { 

        public string ApplicationUserId { get; set; }

        public ICollection<TicketInShoppingCart> TicketInshoppingCart { get; set; }
    }
}

