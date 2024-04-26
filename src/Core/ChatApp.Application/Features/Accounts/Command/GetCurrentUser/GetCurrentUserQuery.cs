using ChatApp.Application.Persistance.Contracts;
using ChatApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Accounts.Command.GetCurrentUser;

public class GetCurrentUserQuery : IRequest<UserReturnDto>
{
    class Handler : IRequestHandler<GetCurrentUserQuery, UserReturnDto>
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenServices _token;

        public Handler(IHttpContextAccessor httpContext,UserManager<AppUser> userManager,ITokenServices token)
        {
            _httpContext = httpContext;
            _userManager = userManager;
            _token = token;
        }
        public async Task<UserReturnDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userName = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type
                == ClaimTypes.GivenName).Value;
                if (userName is not null)
                {
                 var user = await _userManager.FindByNameAsync(userName);
                    return new UserReturnDto()
                    {
                        Email = user.Email,
                        UserName = user.UserName,
                        UserId = user.Id,
                        Token = await _token.CreateToken(user)
                    };
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
