using SAI.Core.Common;

namespace SAI.Core.Entities;

public class SearchAttributeOption : BaseEntity
{
    public Guid AttributeId { get; set; }
    public string Value { get; set; } = null!; 
    public SearchAttribute SearchAttribute { get; set; } = null!;

}