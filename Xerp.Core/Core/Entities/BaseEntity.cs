using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xerp.Core.Entities;

public abstract class BaseEntity
{
    Guid Id { get; set; }
    // meta fields
    string? CreatedBy { get; set; }
    DateTimeOffset? DateCreated { get; set; }
    string? LastModifiedBy { get; set; }
    DateTimeOffset? DateLastModified { get; set; }
    string? DeletedBy { get; set; }
    DateTimeOffset? DateDeleted { get; set; }
    bool IsDeleted { get; set; }
}
