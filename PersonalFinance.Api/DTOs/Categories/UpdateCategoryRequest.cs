using System.ComponentModel.DataAnnotations;
using PersonalFinance.Api.Enums;

namespace PersonalFinance.Api.DTOs.Categories;

public class UpdateCategoryRequest
{
    [Required]
    [StringLength(80)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [EnumDataType(typeof(CategoryType))]
    public CategoryType? Type { get; set; }
}