using Newtonsoft.Json;

namespace Mango.Web.App_Code.Utils
{
	public sealed class Utils
	{
		public static TResult? ConvertTo<TInput, TResult>(TInput input)
		{
			if (input == null)
				throw new ArgumentNullException(nameof(input));

			try
			{
				return JsonConvert.DeserializeObject<TResult>(Convert.ToString(input));
			}
			catch (JsonException ex)
			{
				throw new InvalidOperationException("Conversion failed.", ex);
			}
		}

		public static TResult? ConvertTo<TResult>(object input)
		{
			if (input == null)
				throw new ArgumentNullException(nameof(input));

			try
			{
				return JsonConvert.DeserializeObject<TResult>(Convert.ToString(input));
			}
			catch (JsonException ex)
			{
				throw new InvalidOperationException("Conversion failed.", ex);
			}
		}
	}
}
