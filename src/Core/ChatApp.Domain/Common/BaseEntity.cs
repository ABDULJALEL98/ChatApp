using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate => DateTime.UtcNow;
    public DateTime ModifiedDate { get; set; }
    public bool IsActive { get; set; }
}
