using Mango.Web.Models;
using Mango.Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace Mango.Web.Services.Implementations
{
	public class BaseService : IBaseService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public BaseService(IHttpClientFactory httpClientFactory) 
		{ 
			_httpClientFactory = httpClientFactory;
		}
		public async Task<ResponseDTO?> SendAsync(RequestDTO requestDTO)
		{
			try
			{
				HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
				HttpRequestMessage message = new();
				message.Headers.Add("Accept", "application/json");
				// token
				message.RequestUri = new Uri(requestDTO.URL);

				if (requestDTO.Data != null)
					message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), encoding: Encoding.UTF8, "application/json");

				HttpResponseMessage? apiResponse = null;

				switch (requestDTO.ApiType)
				{
					case Utility.SD.APIType.POST:
						message.Method = HttpMethod.Post;
						break;
					case Utility.SD.APIType.DELETE:
						message.Method = HttpMethod.Delete;
						break;
					case Utility.SD.APIType.PUT:
						message.Method = HttpMethod.Put;
						break;
					default:
						message.Method = HttpMethod.Get;
						break;
				}

				apiResponse = await client.SendAsync(message);

				switch (apiResponse.StatusCode)
				{
					case HttpStatusCode.NotFound:
						return new() { IsSuccess = false, Message = "Not Found" };
					case HttpStatusCode.Forbidden:
						return new() { IsSuccess = false, Message = "Access Denied" };
					case HttpStatusCode.Unauthorized:
						return new() { IsSuccess = false, Message = "Unauthorized" };
					case HttpStatusCode.InternalServerError:
						return new() { IsSuccess = false, Message = "Internal Server Error" };
					default:
						var apiContent = await apiResponse.Content.ReadAsStringAsync();
						var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);

						return apiResponseDTO;
				}
			}
			catch (Exception ex)
			{
				return new()
				{
					Message = ex.Message.ToString(),
					IsSuccess = false,
				};
			}
		}
	}
}
