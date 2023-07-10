using System;
using HomeworkIS_193064.Domain.Domainmodels;
using Microsoft.AspNetCore.Identity;

namespace HomeworkIS_193064.Domain.Identity;

public class ShopAppUser : IdentityUser
{
	public string Name { get; set; }

	public string Surname { get; set; }

    public virtual ShoppingCart UserShoppingCart { get; set; }
}

