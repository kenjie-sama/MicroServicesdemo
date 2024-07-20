namespace Mango.Web.Models;

public class ResponseDTO
{
	public object? Result { get; set; } = null;
	public bool IsSuccess { get; set; } = true;
	public string Message { get; set; } = string.Empty;

}

public class ResponseDTO<T> : ResponseDTO where T : class
{
	public new T? Result
	{
		get => (T?)base.Result;
		set => base.Result = value;
	}
}
