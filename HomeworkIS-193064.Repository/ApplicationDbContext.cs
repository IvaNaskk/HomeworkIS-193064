using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HomeworkIS_193064.Domain.Identity;
using HomeworkIS_193064.Domain.Domainmodels;

namespace HomeworkIS_193064.Repository;

public class ApplicationDbContext : IdentityDbContext<ShopAppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Movie> Movie { get; set; } = default!;
    public virtual DbSet<Ticket> Ticket { get; set; } = default!;
    public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
    public virtual DbSet<TicketInShoppingCart> TicketInShoppingCart { get; set; }
    public virtual DbSet<ShopAppUser> ShopAppUser { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<TicketInOrder> TicketInOrders { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<TicketInShoppingCart>().HasKey(c => new { c.ShoppingCartId, c.TicketId });
        builder.Entity<TicketInOrder>().HasKey(c => new { c.OrderId, c.TicketId });

    }

}

