using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.CleanArchitecture.WebUI.Filters;

namespace Practice.CleanArchitecture.WebUI.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}