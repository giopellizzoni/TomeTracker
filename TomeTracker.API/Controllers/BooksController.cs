using MediatR;

using Microsoft.AspNetCore.Mvc;

using TomeTracker.Application.UseCases.Book.GetBookById;
using TomeTracker.Application.UseCases.Book.Models;

namespace TomeTracker.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{

    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BookRequest request)
    {
        if (!ModelState.IsValid)
        {
            var messages = GetValidatorErrorMessages();
            return BadRequest(messages);
        }

        var bookResponse = await _mediator.Send(request);

        return CreatedAtAction(nameof(GetById), new { id = bookResponse.Id }, bookResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetBookByIdQuery(id);
        var bookResponse = await _mediator.Send(query);

        return Ok(bookResponse);
    }

    private List<String> GetValidatorErrorMessages()
    {
        return ModelState
            .SelectMany(ms => ms.Value?.Errors!)
            .Select(e => e.ErrorMessage)
            .ToList();
    }
}
