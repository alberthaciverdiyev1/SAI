using SAI.Core.Common;

namespace SAI.Core.Entities;

public class SearchAttributeOption : BaseEntity
{
    
    public Guid Id { get; set; }    
    public Guid SearchAttributeId { get; set; }
    public string Value { get; set; } = null!;
    public string ValueId { get; set; } = null!;
    public SearchAttribute SearchAttribute { get; set; } = null!;

}