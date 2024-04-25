using MediatR;

using Microsoft.AspNetCore.Mvc;

using TomeTracker.Application.UseCases.User.Commands;
using TomeTracker.Application.UseCases.User.Queries;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetUserByIdRequest(id);
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
        var query = new GetAllUsersRequest();
        var response = await _mediator.Send(query);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateUserRequest request)
    {
        var updatedResponse = await _mediator.Send(request);

        return Ok(updatedResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var request = new DeleteUserRequest(id);
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
