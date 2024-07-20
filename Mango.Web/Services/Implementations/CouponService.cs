using Mango.Web.Models.DTO;
using Mango.Web.Models;
using Mango.Web.Services.Interfaces;
using Mango.Web.Utility;

namespace Mango.Web.Services.Implementations
{
	public class CouponService : ICouponService
	{
		private readonly IBaseService _baseService;

		public CouponService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task<ResponseDTO?> CreateCouponAsync(CouponDTO couponDTO)
		{
			return await _baseService.SendAsync(new RequestDTO<CouponDTO>
			{
				ApiType = SD.APIType.POST,
				URL = SD.CouponAPIBase + "/api/coupon/",
				Data = couponDTO,
			});
		}

		public async Task<ResponseDTO?> UpdateCouponAsync(CouponDTO couponDTO)
		{
			return await _baseService.SendAsync(new RequestDTO
			{
				ApiType = SD.APIType.PUT,
				URL = SD.CouponAPIBase + "/api/coupon/GetByCode",
				Data = couponDTO
			});
		}

		public async Task<ResponseDTO?> DeleteCouponAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDTO
			{
				ApiType = SD.APIType.DELETE,
				URL = SD.CouponAPIBase + "/api/coupon/".Concat(id.ToString()),
			});
		}

		public async Task<ResponseDTO?> GetCouponByIDAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDTO
			{
				ApiType = SD.APIType.GET,
				URL = SD.CouponAPIBase + "/api/coupon/GetByCode/".Concat(id.ToString()),
			});
		}

		public async Task<ResponseDTO?> GetCouponByCodeAsync(string couponCode)
		{
			return await _baseService.SendAsync(new RequestDTO
			{
				ApiType = SD.APIType.GET,
				URL = SD.CouponAPIBase + "/api/coupon/GetByCode/".Concat(couponCode),
			});
		}


		public async Task<ResponseDTO?> GetAllCouponsAsync()
		{
			return await _baseService.SendAsync(new RequestDTO
			{
				ApiType = SD.APIType.GET,
				URL = SD.CouponAPIBase + "/api/coupon",
			});
		}

	}
}
