using MediatR;

using Microsoft.AspNetCore.Mvc;

using TomeTracker.Application.UseCases.Book.Commands;
using TomeTracker.Application.UseCases.Book.Queries;

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
    public async Task<IActionResult> Post([FromBody] CreateBookRequest request)
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
        if (bookResponse == null)
        {
            return NotFound("Book not found");
        }

        return Ok(bookResponse);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllBooksQuery();
        var bookResponseList = await _mediator.Send(query);

        return Ok(bookResponseList);
    }

    [HttpPut]
    public async Task<IActionResult> Put(
        Guid id,
        [FromBody] UpdateBookRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var request = new DeleteBookRequest(id);
        await _mediator.Send(request);

        return NoContent();
    }

    private List<string> GetValidatorErrorMessages()
    {
        return ModelState
            .SelectMany(ms => ms.Value?.Errors!)
            .Select(e => e.ErrorMessage)
            .ToList();
    }
}
