using Mango.Web.Models.DTO;
using Mango.Web.Models;

namespace Mango.Web.Services.Interfaces
{
	public interface ICouponService
	{
		Task<ResponseDTO?> GetCouponByCodeAsync(string couponCode);
		Task<ResponseDTO?> GetAllCouponsAsync();
		Task<ResponseDTO?> GetCouponByIDAsync(int id);
		Task<ResponseDTO?> CreateCouponAsync(CouponDTO couponDTO);
		Task<ResponseDTO?> UpdateCouponAsync(CouponDTO couponDTO);
		Task<ResponseDTO?> DeleteCouponAsync(int id);

	}
}
