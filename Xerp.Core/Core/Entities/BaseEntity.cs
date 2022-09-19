using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xerp.Core.Entities;

public abstract class BaseEntity {
	public Guid Id { get; set; }
	// meta fields
	public string? CreatedBy { get; set; }
	public DateTimeOffset? DateCreated { get; set; }
	public string? LastModifiedBy { get; set; }
	public DateTimeOffset? DateLastModified { get; set; }
	public string? DeletedBy { get; set; }
	public DateTimeOffset? DateDeleted { get; set; }
	public bool IsDeleted { get; set; }
}
