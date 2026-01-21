using Microsoft.AspNetCore.Mvc;
using SAI.API.Controllers.Base;
using SAI.Core.DTOs.SearchAttribute;
using SAI.Core.Interfaces.Services;

namespace SAI.API.Controllers;

[ApiController]
[Route("search-attribute")]
public class SearchAttributeController(ISearchAttributeService service) : CustomBaseController
{
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync() => CreateActionResult(await service.GetAllAsync());
    
    
}