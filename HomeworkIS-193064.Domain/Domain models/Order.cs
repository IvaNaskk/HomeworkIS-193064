using System;
using System.ComponentModel.DataAnnotations;
using HomeworkIS_193064.Domain.Identity;

namespace HomeworkIS_193064.Domain.Domainmodels
{
	public class Order : BaseEntity
	{

		public string UserId { get; set; }

		public ShopAppUser OrderdBy { get; set; }

		public List<TicketInOrder> Tickets { get; set; }


	}
}

