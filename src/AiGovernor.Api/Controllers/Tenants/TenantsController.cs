using AiGovernorPortal.Application.Tenants.CreateTenant;
using AiGovernorPortal.Application.Tenants.ListTenants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AiGovernor.Api.Controllers.Tenants;
[Route("api/tenants")]
[ApiController]
public class TenantsController(ISender sender) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTenant(
        Guid id,
        CancellationToken cancellationToken)
    {
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> ListTenants(
        int page,
        int pageSize,
        CancellationToken cancellationToken)
    {
        var query = new ListTenantsQuery(page, pageSize);
        var result = await sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTenant(
        CreateTenantRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateTenantCommand(
            request.Name,
            request.Subdomain,
            request.Email,
            request.Address,
            request.Company);

        var result = await sender.Send(command, cancellationToken);
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetTenant), new { id = result.Value }, result.Value);
    }
}
