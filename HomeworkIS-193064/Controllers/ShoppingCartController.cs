//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace HomeworkIS_193064.Controllers
//{
//    public class ShoppingCartController : Controller
//    {

//        private readonly ApplicationDbContext _context;

//        public ShoppingCartController(ApplicationDbContext context)
//        {
//            _context = context;
//        }


//        // GET: /<controller>/
//        public IActionResult Index()
//        {
//            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            var user = _context.Users.Where(z => z.Id == userId).Include("UserShoppingCart.TicketInshoppingCart")
//                .Include("UserShoppingCart.TicketInshoppingCart.Ticket")
//                .FirstOrDefault();

//            var userShoppingCart = user.UserShoppingCart;

//            var ticketList = userShoppingCart.TicketInshoppingCart.Select(z => new
//            {
//                Quantity = z.Quantity,
//                TicketPrice = z.Ticket.Price
//            }) ;

//            float totalPrice = 0;
//            foreach (var item in ticketList)
//            {
//                totalPrice += item.TicketPrice * item.Quantity;
//            }

//            ShoppingCartDto model = new ShoppingCartDto
//            {
//                TotalPrice = totalPrice,
//                TicketInShoppingCart = userShoppingCart.TicketInshoppingCart.ToList()
//            };

//            return View(model);
//        }

//        public IActionResult DeleteFromShoppingCart(int id)
//        {
//            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            var user = _context.Users.Where(z => z.Id == userId).Include("UserShoppingCart.TicketInshoppingCart")
//                .Include("UserShoppingCart.TicketInshoppingCart.Ticket")
//                .FirstOrDefault();

//            var userShoppingCart = user.UserShoppingCart;

//            var forRemoval = userShoppingCart.TicketInshoppingCart.Where(z => z.TicketId == id).FirstOrDefault();
//            userShoppingCart.TicketInshoppingCart.Remove(forRemoval);
//            _context.Update(userShoppingCart);
//            _context.SaveChanges();

//            return RedirectToAction("Index");

//        }

//        public IActionResult OrderNow()
//        {
//            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            var user = _context.Users.Where(z => z.Id == userId).Include("UserShoppingCart.TicketInshoppingCart")
//                .Include("UserShoppingCart.TicketInshoppingCart.Ticket")
//                .FirstOrDefault();

//            var userShoppingCart = user.UserShoppingCart;

//            Order newOrder = new Order
//            {
//                UserId = userId,
//                OrderdBy = user
//            };

//            _context.Add(newOrder);
//            _context.SaveChanges();

//            List<TicketInOrder> ticketInOrders = userShoppingCart.TicketInshoppingCart.Select( z => new TicketInOrder
//            {
//                Ticket = z.Ticket,
//                TicketId =z.TicketId,
//                Order = newOrder,
//                OrderId = newOrder.OrderId
//            }).ToList();

//            foreach(var item in ticketInOrders)
//            {
//                _context.Add(item);
//            }
//            user.UserShoppingCart.TicketInshoppingCart.Clear();
//            _context.Update(user);
//            _context.SaveChanges();

//            return RedirectToAction("Index");

//        }
//    }
//}

