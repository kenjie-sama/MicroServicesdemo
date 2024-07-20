using Mango.Web.Models;
using Mango.Web.Models.DTO;
using Mango.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Mango.Web.App_Code.Utils;

namespace Mango.Web.Controllers
{
	public class CouponController : Controller
	{
		private readonly ICouponService _couponService;

		public CouponController(ICouponService couponService)
		{
			_couponService = couponService;
		}


		public async Task<IActionResult> Index()
		{
			List<CouponDTO> coupons = new();
			ResponseDTO response= await _couponService.GetAllCouponsAsync();

			if (response != null && response.IsSuccess)
				coupons = Utils.ConvertTo<List<CouponDTO>>(response.Result);

			return View(coupons);
		}
	}
}
