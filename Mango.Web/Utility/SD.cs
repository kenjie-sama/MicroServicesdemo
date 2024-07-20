namespace Mango.Web.Utility
{
	public class SD
	{
		public sealed class Links {
			//public void RegisterConfigs(string couponApiUrl, )
			//{
			//		CouponAPIRoot = builder.Configuration["ServiceURLs:CouponAPI"];
			//		CouponAPIRoot = SD.Links.CouponAPIRoot.Concat("/api/");
			//}
			public void RegisterConfigs(ConfigurationManager config)
			{
				CouponAPIRoot = config["ServiceURLs:CouponAPI"].ToString();
				CouponAPIBase = CouponAPIRoot.Concat("/api/coupon").ToString();
			}
			public static string CouponAPIRoot { get; set; }
			public static string CouponAPIBase { get; set; }
		}

		public enum APIType
		{
			GET, POST, PUT, DELETE,
		}
	}
}
