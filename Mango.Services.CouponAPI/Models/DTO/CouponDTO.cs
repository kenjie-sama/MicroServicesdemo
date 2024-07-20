using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models.DTO
{
	public class CouponDTO
	{
		public int ID { get; set; }
		public string CouponCode { get; set; }
		public int DiscountAmount { get; set; }
		public int MinAmount { get; set; }
	}
}
