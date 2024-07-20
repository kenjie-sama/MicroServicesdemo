using static Mango.Web.Utility.SD;

namespace Mango.Web.Models;


public class RequestDTO
{
	public APIType ApiType { get; set; } = APIType.GET;
	public string URL { get; set; }
	public object Data { get; set; }
	public string AccessToken { get; set; }
}


public class RequestDTO<T> : RequestDTO where T : class
{
	public new T? Data
	{
		get => (T?)base.Data;
		set => base.Data = value;
	}
}