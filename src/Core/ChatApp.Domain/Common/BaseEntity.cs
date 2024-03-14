using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateOnly CreatedDate => DateOnly.FromDateTime(DateTime.UtcNow);
    public DateOnly ModifiedDate { get; set; }
    public bool IsActive { get; set; }
}
