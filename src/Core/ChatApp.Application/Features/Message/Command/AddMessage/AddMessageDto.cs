namespace ChatApp.Application.Features.Message.Command.AddMessage;

public class AddMessageDto
{
    public int SenderId { get; set; }

    public int RecipientId { get; set; }
    public string Content { get; set; } = String.Empty;
    public DateTime? DateRead { get; set; }

}
