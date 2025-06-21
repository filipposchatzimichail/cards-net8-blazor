using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Logicea.Cards.DataAccess.Models;

public class Card : BaseEntity
{
    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; } = "New Card Name";
    public string? Description { get; set; }

    [ColorHex]
    public string? Color { get; set; }
    public CardStatus Status { get; set; } = CardStatus.ToDo;
}


public enum CardStatus
{
    ToDo,
    InProgress,
    Done
}



public class ColorHexAttribute : ValidationAttribute
{
    private static readonly Regex HexColorRegex = new(@"^#([0-9a-fA-F]{6})$");

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string color && !string.IsNullOrWhiteSpace(color))
        {
            if (!HexColorRegex.IsMatch(color))
            {
                return new ValidationResult("Color must be a valid hex code (e.g. #FFFFFF or #6a6a6a).");
            }
        }

        return ValidationResult.Success;
    }
}