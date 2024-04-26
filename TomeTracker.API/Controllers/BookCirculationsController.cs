using MediatR;

using Microsoft.AspNetCore.Mvc;

using TomeTracker.Application.UseCases.BookCirculation.Commands;
using TomeTracker.Application.UseCases.BookCirculation.Queries;

namespace TomeTracker.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BookCirculationsController: ControllerBase
{
    private readonly IMediator _mediator;

    public BookCirculationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCirculationRequest request)
    {
        var response = await _mediator.Send(request);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetCirculationByIdQuery(id);
        var response = await _mediator.Send(query);
        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet("{date}")]
    public async Task<IActionResult> GetByDate(DateTime date)
    {
        var query = new GetCirculationByDateQuery(date);
        var response = await _mediator.Send(query);
        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllCirculationQuery();
        var circulations = await _mediator.Send(query);

        return Ok(circulations);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Finish(Guid id)
    {
        var request = new FinishCirculationRequest(id);
        await _mediator.Send(request);

        return NoContent();
    }
}
