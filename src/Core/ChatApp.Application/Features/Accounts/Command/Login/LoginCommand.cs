using AutoMapper;
using ChatApp.Application.Persistance.Contracts;
using ChatApp.Application.Responses;
using ChatApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Accounts.Command.Login;

public class LoginCommand:IRequest<BaseCommonResponse>
{
    public LoginDto LoginDto { get; set; }

    public LoginCommand(LoginDto loginDto)
    {
        LoginDto = loginDto;
    }
    class Handler : IRequestHandler<LoginCommand, BaseCommonResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenServices _tokenServices;

        public Handler(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,IMapper mapper,
            SignInManager<AppUser> signInManager, ITokenServices tokenServices)
            
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
        }
        public async Task<BaseCommonResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            BaseCommonResponse res = new();
            try
            {
               
                var user =await _userManager.FindByNameAsync(request.LoginDto.UserName);
                if(user is not null)
                {
                    var result =await _signInManager.CheckPasswordSignInAsync(user,request.LoginDto.Password,lockoutOnFailure:false);
                    if(result is not null && result.Succeeded)
                    {
                        res.IsSuccess = true;
                        res.Message = "Login Sucess";
                        res.Data = new
                        {
                            userName = user.UserName,
                            email = user.Email,
                            token = _tokenServices.CreateToken(user)
                        };
                        return res;
                    }
                    res.IsSuccess = false;
                    res.Message = "unAuthorized";
                    return res;
                }
                res.IsSuccess = false;
                res.Message = "notFound";
                return res;

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.InnerException.Message;
                return res;
            }
        }
    }
}
