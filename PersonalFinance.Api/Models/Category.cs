using System.ComponentModel.DataAnnotations;
using PersonalFinance.Api.Enums;

namespace PersonalFinance.Api.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(80)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public CategoryType Type { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = [];
}
