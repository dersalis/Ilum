using System;
namespace Ilum.Api.Shared
{
	public class Response
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }

		public static Response Success(string message = "") => new()
		{
			IsSuccess = true,
			Message = message
		};

		public static Response Failure(string message) => new()
		{
			IsSuccess = false,
			Message = message
		};
	}
}

