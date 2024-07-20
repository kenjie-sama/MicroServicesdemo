using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace Mango.Services.CouponAPI.Controllers
{
	[Route("api/coupon")]
	[ApiController]
	public class CouponAPIController : ControllerBase
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public CouponAPIController(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public ResponseDTO<IEnumerable<CouponDTO>> Get()
		{
			ResponseDTO<IEnumerable<CouponDTO>> _reponse = new();

			try
			{
				IEnumerable<Coupon> coupons = _context.Coupons.ToList();
				_reponse.Result = _mapper.Map<IEnumerable<CouponDTO>>(coupons);
			}
			catch (Exception ex)
			{
				_reponse.IsSuccess = false;
				_reponse.Message = ex.Message;
			}

			return _reponse;
		}


		[HttpGet]
		[Route("{id:int}")]
		public ResponseDTO<CouponDTO> Get(int id)
		{
			ResponseDTO<CouponDTO> _reponse = new();

			try
			{
				Coupon coupon = _context.Coupons.First(c => c.ID == id);

				if (coupon == null)
					_reponse.IsSuccess = false;

				_reponse.Result = _mapper.Map<CouponDTO>(coupon);
			}
			catch (Exception ex)
			{
				_reponse.IsSuccess = false;
				_reponse.Message = ex.Message;
			}

			return _reponse;
		}

		[HttpGet]
		[Route("GetByCode/{code}")]
		public ResponseDTO<CouponDTO> GetByCode(string code)
		{
			ResponseDTO<CouponDTO> _reponse = new();

			try
			{
				Coupon coupon = _context.Coupons.FirstOrDefault(c => c.CouponCode.ToLower() == code.ToLower());

				if (coupon == null)
					_reponse.IsSuccess = false;

				_reponse.Result = _mapper.Map<CouponDTO>(coupon);
			}
			catch (Exception ex)
			{
				_reponse.IsSuccess = false;
				_reponse.Message = ex.Message;
			}

			return _reponse;
		}


		[HttpPost]
		public ResponseDTO<CouponDTO> Post([FromBody] CouponDTO couponDTO)
		{
			ResponseDTO<CouponDTO> _reponse = new();

			try
			{
				Coupon coupon = _mapper.Map<Coupon>(couponDTO);

				_context.Coupons.Add(coupon);
				_context.SaveChanges();

				_reponse.Result = _mapper.Map<CouponDTO>(coupon);
			}
			catch (Exception ex)
			{
				_reponse.IsSuccess = false;
				_reponse.Message = ex.Message;
			}

			return _reponse;
		}

		[HttpDelete]
		[Route("{id:int}")]
		public ResponseDTO<CouponDTO> Delete(int id)
		{
			ResponseDTO<CouponDTO> _reponse = new();

			try
			{
				Coupon coupon = _context.Coupons.Find(id);

				if (coupon != null)
				{
					_context.Coupons.Remove(coupon);
					_context.SaveChanges();

					_reponse.Result = _mapper.Map<CouponDTO>(coupon);
				}
				else
				{
					_reponse.IsSuccess = false;
				}
			}
			catch (Exception ex)
			{
				_reponse.IsSuccess = false;
				_reponse.Message = ex.Message;
			}

			return _reponse;
		}

		[HttpPut]
		public ResponseDTO<CouponDTO> Put([FromBody] CouponDTO couponDTO)
		{
			ResponseDTO<CouponDTO> _reponse = new();

			try
			{
				Coupon coupon = _mapper.Map<Coupon>(couponDTO);

				if (coupon != null)
				{
					_context.Coupons.Update(coupon);
					_context.SaveChanges();

					_reponse.Result = _mapper.Map<CouponDTO>(coupon);
				}
				else
				{
					_reponse.IsSuccess = false;
				}

			}
			catch (Exception ex)
			{
				_reponse.IsSuccess = false;
				_reponse.Message = ex.Message;
			}

			return _reponse;
		}
	}
}
