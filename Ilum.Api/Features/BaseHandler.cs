using System;
using AutoMapper;
using Ilum.Domain.Context;

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

