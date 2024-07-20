using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models
{
	public class Coupon
	{
		[Key] public int ID { get; set; }
		[Required] public string CouponCode {  get; set; }
		[Required] public int DiscountAmount { get; set; }
		[Required] public int MinAmount { get; set; }
	}
}
