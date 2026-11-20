using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PersonalFinance.Api.Enums;

namespace PersonalFinance.Api.Models;

public class Transaction
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [StringLength(120)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    public TransactionType Type { get; set; }

    public DateOnly TransactionDate { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
