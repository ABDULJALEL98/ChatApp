using AutoMapper;
using ChatApp.Application.Features.Message.Command.AddMessage;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.MappingProfiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Message, AddMessageDto>().ReverseMap();
    }
}
