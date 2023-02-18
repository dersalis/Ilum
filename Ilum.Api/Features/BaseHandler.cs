using System;
using Ilum.Api.Context;
using AutoMapper;

namespace Ilum.Api.Features
{
	public class BaseHandler
	{
		protected readonly IIlumContext _ilumContext;
		protected readonly IMapper _mapper;
        private IIlumContext ilumContext;

        public BaseHandler(IIlumContext ilumContext)
        {
            this.ilumContext = ilumContext;
        }

        public BaseHandler(IIlumContext ilumContext, IMapper mapper)
		{
			_ilumContext = ilumContext;
			_mapper = mapper;
		}
	}
}

