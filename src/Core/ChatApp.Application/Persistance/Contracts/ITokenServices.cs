using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Persistance.Contracts;

public interface ITokenServices
{
    Task CreateToken(AppUser user);
    string GetToken(AppUser user);
}
