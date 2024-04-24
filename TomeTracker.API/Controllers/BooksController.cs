using MediatR;

using Microsoft.AspNetCore.Mvc;

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
            var messages = ModelState
                .SelectMany(ms => ms.Value?.Errors!)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(messages);
        }

        var book = await _mediator.Send(request);

        return Ok(book);
    }
}
