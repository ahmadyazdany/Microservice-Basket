using ApplicationService.Handlers.Authenticated;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BasketController : BaseController
{
    [HttpPost("AddItem")]
    public async Task<IActionResult> AddItem(
        [FromBody] AddItemCommand command,
        [FromServices] AddItemHandler handler,
        CancellationToken cancellationToken)
    {
        await handler.Execute(command, cancellationToken);
        return Ok();
    }
}
