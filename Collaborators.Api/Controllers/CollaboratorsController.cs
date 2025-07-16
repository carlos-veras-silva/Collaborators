using Collaborators.Application.Commands.Collaborators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Collaborators.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ColaboratorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ColaboratorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateColaboradorCommand command)
    {
        var colaboradorId = await _mediator.Send(command);
        return Ok(new { Id = colaboradorId });
    }




}