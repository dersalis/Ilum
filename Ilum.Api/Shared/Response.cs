using System;
namespace Ilum.Api.Shared
{
	public class Response
	{
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
		public int Id { get; set; } = -1;

		public static Response Success(string message = "") => new()
		{
			IsSuccess = true,
			Message = message
		};

        public static Response Success(int id, string message = "") => new()
        {
            IsSuccess = true,
			Id = id
        };

        public static Response Failure(string message) => new()
		{
			IsSuccess = false,
			Message = message
		};
	}
}

