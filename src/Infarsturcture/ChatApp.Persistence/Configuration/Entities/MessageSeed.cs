using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Persistence.Configuration.Entities;

public class MessageSeed : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
       builder.HasData(
           new Message()
          {
               Id = 1,
              Content = "test-one",
              SenderId = 1,
              SenderUserName = "ali",
              RecipientId = 1,
              RecipientUserName = "ahmed",
              IsActive
               = true
          },
             new Message()
             {
                 Id = 2,
                 Content = "test-two",
                 SenderId = 1,
                 SenderUserName = "mohamad",
                 RecipientId = 1,
                 RecipientUserName = "ahmed",
                 IsActive
               = true
             },
              new Message()
              {
                  Id = 3,
                  Content = "test-two",
                  SenderId = 1,
                  SenderUserName = "basem",
                  RecipientId = 1,
                  RecipientUserName = "ahmed",
                  IsActive
               = true
              }
              );
    }
}
