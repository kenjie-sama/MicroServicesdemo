using Mango.Web.Models;

namespace Mango.Web.Services.Interfaces
{
	public interface IBaseService
	{
		Task<ResponseDTO?> SendAsync(RequestDTO requestDTO);
	}
}
