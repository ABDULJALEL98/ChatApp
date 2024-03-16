using ChatApp.Application.Persistance.Contracts;
using ChatApp.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Persistence.Repositories;

public class MessageRepository : GenericRepository<Domain.Entities.Message>,IMessageReopsitory
{
    public MessageRepository(AppliactionDbContext context) : base(context)
    {
    }
    //for future
}
