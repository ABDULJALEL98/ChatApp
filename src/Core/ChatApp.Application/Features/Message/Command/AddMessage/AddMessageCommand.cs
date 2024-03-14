using AutoMapper;
using ChatApp.Application.Features.Message.Validator;
using ChatApp.Application.Persistance.Contracts;
using ChatApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Message.Command.AddMessage;

public class AddMessageCommand:IRequest<BaseCommonResponse> 
{
    public AddMessageDto AddMessageDto { get; set; }
    public AddMessageCommand(AddMessageDto addMessageDto)
    {
        AddMessageDto = addMessageDto;
    }
    class Handler : IRequestHandler<AddMessageCommand, BaseCommonResponse>
    {
        private readonly IMessageReopsitory _messageReopsitory;
        private readonly IMapper _mapper;

        public Handler(IMessageReopsitory messageReopsitory,IMapper mapper)
        {
            _messageReopsitory = messageReopsitory;
            _mapper = mapper;
        }
        public async Task<BaseCommonResponse> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                BaseCommonResponse response = new();
                MessageValidator validations = new();
                var validatorResult = await validations.ValidateAsync(request.AddMessageDto);
                if (!validatorResult.IsValid)
                {
                    response.IsSuccess = false;
                    response.Message = "While Adding New Message";
                    response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                }


                    await _messageReopsitory.AddAsync(_mapper.Map<Domain.Entities.Message>(request.AddMessageDto));
                response.IsSuccess = true;
                response.Message = "Success Adding New Message";
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
