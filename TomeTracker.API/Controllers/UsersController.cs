using MediatR;

using Microsoft.AspNetCore.Mvc;

using TomeTracker.Application.UseCases.User.Commands;

namespace TomeTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController: ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
    {
        if (!ModelState.IsValid)
        {
            var messages = GetValidatorErrorMessages();
            return BadRequest(messages);
        }

        var userResponse = await _mediator.Send(request);

        return Ok(userResponse);
    }

    private List<string> GetValidatorErrorMessages()
    {
        return ModelState
            .SelectMany(ms => ms.Value?.Errors!)
            .Select(e => e.ErrorMessage)
            .ToList();
    }

}
