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
        var book = await _mediator.Send(request);

        return Ok(book);
    }
}
