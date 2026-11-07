using PersonalFinance.Api.Enums;

namespace PersonalFinance.Api.Models;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public CategoryType Type { get; set; }
}