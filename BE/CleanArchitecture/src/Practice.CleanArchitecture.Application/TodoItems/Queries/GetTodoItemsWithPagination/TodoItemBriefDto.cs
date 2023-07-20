using Practice.CleanArchitecture.Application.Common.Mappings;
using Practice.CleanArchitecture.Domain.Entities;

namespace Practice.CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}
