using SAI.Core.Common;

namespace SAI.Core.Entities;

public class SearchAttribute:BaseEntity
{
    public string Key { get; set; } = null!;  
    public ICollection<SearchAttributeOption> Options { get; set; } = new List<SearchAttributeOption>();
    
}