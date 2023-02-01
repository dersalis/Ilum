using System;
using Ilum.Api.Context;

namespace Ilum.Api.Features
{
	public class BaseHandler
	{
		protected readonly IIlumContext _ilumContext;

		public BaseHandler(IIlumContext ilumContext)
		{
			_ilumContext = ilumContext;
		}
	}
}

