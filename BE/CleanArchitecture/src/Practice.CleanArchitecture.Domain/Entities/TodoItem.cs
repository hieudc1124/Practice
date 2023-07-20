using Practice.CleanArchitecture.Domain.Common;
using Practice.CleanArchitecture.Domain.Enums;

namespace Practice.CleanArchitecture.Domain.Entities;

public class TodoItem : BaseEntity
{
    public int ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    public TodoList List { get; set; } = null!;
}