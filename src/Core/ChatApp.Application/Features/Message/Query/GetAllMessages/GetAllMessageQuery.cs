using AutoMapper;
using ChatApp.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Message.Query.GetAllMessages;

public class GetAllMessageQuery:IRequest<List<MessageReturnDto>>
{
    
    class Handler : IRequestHandler<GetAllMessageQuery, List<MessageReturnDto>>
    {
        private readonly IMessageReopsitory _messageReopsitory;
        private readonly IMapper _mapper;

        public Handler(IMessageReopsitory messageReopsitory,IMapper mapper)
        {
            _messageReopsitory = messageReopsitory;
            _mapper = mapper;
        }
        public async Task<List<MessageReturnDto>> Handle(GetAllMessageQuery request, CancellationToken 
            cancellationToken)
        {
           try
            {
                var allMessage = await _messageReopsitory.GetAllAsync();
                var mappingMesg = _mapper.Map<List<MessageReturnDto>>(allMessage);
                return mappingMesg;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
