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

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id) => CreateActionResult(await service.GetByIdAsync(id));
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(SearchAttributeCreateRequest request) => CreateActionResult(await service.CreateAsync(request));
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, SearchAttributeUpdateRequest request) => CreateActionResult(await service.UpdateAsync(id, request));
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id) => CreateActionResult(await service.DeleteAsync(id));

    
}