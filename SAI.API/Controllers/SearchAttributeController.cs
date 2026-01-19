using Microsoft.AspNetCore.Mvc;
using SAI.Core.DTOs.SearchAttribute;
using SAI.Core.Interfaces.Services;

namespace SAI.API.Controllers;

[ApiController]
[Route("search-attributes")]
public class SearchAttributeController(ISearchAttributeService service) : Controller
{

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SearchAttributeResponse>>> GetAllAsync() => Ok(await service.GetAllAsync());
    
    
}