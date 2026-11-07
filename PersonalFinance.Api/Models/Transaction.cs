using PersonalFinance.Api.Enums;

namespace PersonalFinance.Api.Models;

public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public DateOnly TransactionDate { get; set; }
    public bool IsDeleted { get; set; } = false;

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}
