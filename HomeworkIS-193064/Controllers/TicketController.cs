using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using HomeworkIS_193064.Service.Interface;
using HomeworkIS_193064.Domain.DTO;
using HomeworkIS_193064.Domain.Domainmodels;

namespace TicketApp.Controllers

{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {

            _ticketService = ticketService;

        }

        // GET: Ticket

        public async Task<IActionResult> Index()
        {
            return View(_ticketService.GetAllTickets());
        }

        public async Task<IActionResult> AddToCart(int ticketId)
        {
            var ticket = _ticketService.GetDetailsForTicket(ticketId);
            var model = new AddToShoppingCartDto();
            model.SelectedTicket = ticket;
            model.TicketId = ticket.Id;
            model.Quantity = 0;
            //var cart = _context.ShoppingCart.Include(c => c.TicketInshoppingCart).FirstOrDefault(z => z.ShoppingCartId == cartId);
            //var movie = _context.Movie.FirstOrDefault(m => m.Id == movieId);

            //ticket.Movie = movie;

            //if (ticket == null || cart == null)
            //{
            //    // Handle the case when ticket or cart is not found
            //    return NotFound();
            //}

            //var ticketInShoppingCart = new TicketInShoppingCart
            //{
            //    ShoppingCartId = cart.ShoppingCartId,
            //    TicketId = ticket.TicketId
            //};

            //cart.TicketInshoppingCart.Add(ticketInShoppingCart);

            //_context.TicketInShoppingCart.Add(ticketInShoppingCart);
            //await _context.SaveChangesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToShoppingCart(AddToShoppingCartDto model)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var user = _context.Users.Where(z => z.Id == userId)
            //    .Include("UserShoppingCart.TicketInshoppingCart")
            //    .Include("UserShoppingCart.TicketInshoppingCart.Ticket")
            //    .FirstOrDefault();

            //var userShoppingCart = user.UserShoppingCart;
            //if (userShoppingCart != null)
            //{
            //    var ticket = _context.Ticket.Find(model.TicketId);
            //    if (ticket != null)
            //    {
            //        TicketInShoppingCart itemToAdd = new TicketInShoppingCart
            //        {
            //            Ticket = ticket,
            //            TicketId = ticket.TicketId,
            //            ShoppingCart = userShoppingCart,
            //            Quantity = model.Quantity

            //        };
            //        _context.Add(itemToAdd);
            //        await _context.SaveChangesAsync();
            //    }
            //}

            return RedirectToAction("Index");

        }


        // GET: Ticket/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id??0);
           
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }


        // GET: Ticket/Create

        public IActionResult Create()
        {
            //ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");

            return View();
        }


        // POST: Ticket/Create

        // To protect from overposting attacks, enable the specific properties you want to bind to.

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create( Ticket ticket)
        {
            //Movie movie = await _context.Movie.FindAsync(ticket.MovieId);

            //if (movie == null)
            //{
            //    // Movie not found, handle the error
            //    Console.WriteLine("Movie not found for the provided MovieId.");
            //    return RedirectToAction(nameof(Index));
            //}

            //// Associate the movie object with the ticket
            //ticket.Movie = movie;
            //Console.WriteLine($"Ticket Details: Id={ticket.TicketId}, Date={ticket.Date}, Hall={ticket.Hall}, MovieId={ticket.MovieId}, Movie={ticket.Movie.Title}");

            //_context.Add(ticket);
            //await _context.SaveChangesAsync();

            if (ModelState.IsValid)
            {
                _ticketService.CreateNewTicket(ticket);
                return RedirectToAction(nameof(Index));

            }

            return View(ticket);

        }


        // GET: Ticket/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id??0);

            if (ticket == null)
            {
                return NotFound();
            }

            //ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", ticket.MovieId);

            return View(ticket);
        }


        // POST: Ticket/Edit/5

        // To protect from overposting attacks, enable the specific properties you want to bind to.

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            _ticketService.UpdateExistingTicket(ticket);

            //_context.Update(ticket);
            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: Ticket/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id ?? 0);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Ticket/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _ticketService.DeleteTicket(id);

            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _ticketService.GetDetailsForTicket(id) != null;
        }

    }

}
