using System;
using HomeworkIS_193064.Domain.Domainmodels;
using HomeworkIS_193064.Domain.DTO;

namespace HomeworkIS_193064.Service.Interface

{
	public interface ITicketService
	{
		List<Ticket> GetAllTickets();

		Ticket GetDetailsForTicket(int id);

		void CreateNewTicket(Ticket t);

		void UpdateExistingTicket(Ticket t);

		ShoppingCartDto GetShoppingCartInfo(int id);

		void DeleteTicket(int id);

		bool AddToShoppingCart(ShoppingCartDto item, string userID);
	}
}

