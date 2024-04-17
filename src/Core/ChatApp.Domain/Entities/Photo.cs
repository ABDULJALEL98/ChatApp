using ChatApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Entities;

public class Photo:BaseEntity
{
    public string Url { get; set; } = string.Empty;
    public bool IsMain { get; set; }
    public string PublicId { get; set; } = string.Empty;

    public string AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }

}
