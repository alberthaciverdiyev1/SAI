using Microsoft.AspNetCore.Mvc;
using SAI.API.Controllers.Base;
using SAI.Core.DTOs.SearchAttribute;
using SAI.Core.DTOs.SearchAttributeOption;
using SAI.Core.Interfaces.Services;

namespace SAI.API.Controllers;

[Route("search-attribute/option")]
public class SearchAttributeOptionController(ISearchAttributeOptionService service) : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(SearchAttributeOptionCreateRequest request) =>
        CreateActionResult(await service.AddAsync(request));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, SearchAttributeOptionUpdateRequest request) =>
        CreateActionResult(await service.UpdateAsync(id, request));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id) => CreateActionResult(await service.DeleteAsync(id));
}