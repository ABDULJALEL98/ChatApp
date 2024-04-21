using ChatApp.Application.Responses;
using ChatApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Accounts.Command.Register;

public class RegisterCommand:IRequest<BaseCommonResponse>
{
    public RegisterDto RegisterDto { get; set; }

    public RegisterCommand(RegisterDto registerDto)
    {
        RegisterDto = registerDto;
    }

    class Handler : IRequestHandler<RegisterCommand, BaseCommonResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public Handler(UserManager<AppUser> userManager)
        {
           _userManager = userManager;
        }
        public async Task<BaseCommonResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            BaseCommonResponse res = new();
           try
            {
                var user = new AppUser()
                {
                    Email = request.RegisterDto.Email,
                    UserName = request.RegisterDto.UserName,
                };
               var response = await _userManager.CreateAsync(user, request.RegisterDto.Password);
                if(response.Succeeded == false)
                {
                    foreach(var err in response.Errors)
                    {
                        res.Errors.Add(item: $"{err.Code} = {err.Description}");
                    }
               
                    res.IsSuccess = false;
                    res.Message = "badRequste";
                    return res;
                }
                res.IsSuccess = true;
                res.Message = "register success";
                res.Data = new
                {
                    userName = user.UserName,
                    email = user.Email,
                    token = ""
                };
            return res;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;

                return res;
            }
        }
    }
}
