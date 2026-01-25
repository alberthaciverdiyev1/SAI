using Microsoft.AspNetCore.Mvc;
using SAI.API.Controllers.Base;
using SAI.Core.DTOs.Parser;
using SAI.Core.DTOs.SearchAttribute;
using SAI.Core.Interfaces.Services;
using SAI.Infrastructure.Services;

namespace SAI.API.Controllers;

[Route("ai-search")]
public class UserSearchController(SearchQueryBuilderService service) : CustomBaseController
{
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] UserSearchRequest request) 
    {
        var result = await service.BuildSearchUrl(request.Message);
        return CreateActionResult(result);
    }    
    
}