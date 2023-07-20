using Practice.CleanArchitecture.Domain.Common;

namespace Practice.CleanArchitecture.Domain.Entities;

public class TodoList : BaseEntity
{
    public string? Title { get; set; }

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
