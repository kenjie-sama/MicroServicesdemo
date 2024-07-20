using System;

public class APIMappingConfig
{
	public APIMappingConfig()
	{
		public static MapperConfiguration Initialize()
		{
			var mappingConfig = new MapperConfiguration(
				config =>
				{
					config.CreateMap<CouponDTO, Coupon>();
					config.CreateMap<Coupon, CouponDTO>();
				});

			return mappingConfig;
		}
	}
}
