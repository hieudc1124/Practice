using Microsoft.AspNetCore.Mvc;
using Practice.CleanArchitecture.Application.Common.Models;
using Practice.CleanArchitecture.Application.Common.Services;
using Practice.CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using Practice.CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace Practice.CleanArchitecture.WebUI.Controllers;

public class TodoItemController : ApiControllerBase
{
    private ISendMailService _sendMailService;

    public TodoItemController(ISendMailService sendMailService)
    {
        _sendMailService = sendMailService;
    }
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
    {
        await _sendMailService.SendAsync(new MailContent()
        {

        });
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
    }
}