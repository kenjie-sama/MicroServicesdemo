using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public virtual DbSet<Coupon> Coupons { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Coupon>().HasData(
				new Coupon
				{
					ID = 1,
					CouponCode = "DY19N",
					DiscountAmount = 10,
					MinAmount = 20,
				}
			);
			modelBuilder.Entity<Coupon>().HasData(
				new Coupon
				{
					ID = 2,
					CouponCode = "P110N",
					DiscountAmount = 20,
					MinAmount = 50,
				}
			);
		}
	}
}
