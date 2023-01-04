using ImanWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImanWebApp.DataAccess.Data;

public class MyApplicationDbContext : IdentityDbContext
{
	public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options) : base(options)
	{
	}

    public DbSet<Category> Category { get; set; }
	public DbSet<FoodType> FoodType { get; set; }
	public DbSet<MenuItem> MenuItem { get; set; }
	public DbSet<ApplicationUser> ApplicationUser { get; set; }
		
}
