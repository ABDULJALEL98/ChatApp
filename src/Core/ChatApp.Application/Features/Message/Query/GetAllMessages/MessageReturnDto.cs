using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Message.Query.GetAllMessages;

public class MessageReturnDto
{
    public string Content { get; set; } = string.Empty;
    public DateTime? DateRead { get; set; }
    public string SenderUserName { get; set; } = string.Empty;
    public string RecipientUserName {  get; set; } = string.Empty;


}
