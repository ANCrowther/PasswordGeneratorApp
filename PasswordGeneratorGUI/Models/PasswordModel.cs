using System.ComponentModel.DataAnnotations;

namespace PasswordGeneratorGUI.Models;
public class PasswordModel {
    [Required]
    public string AllowedSpecialCharacters { get; set; } = "!, @, #, ^";
    [Required]
    public int MinimumLength { get; set; } = 8;
    [Required]
    public int MaximumLength { get; set;} = 16;
    [Required]
    public int MinimumSpecialCharacters { get; set; } = 2;
    [Required]
    public int MinimumNumbers { get; set; } = 2;
    [Required]
    public string Password { get; set; } = "";

    public int SpecialCharacterCount { get; set; } = 0;
    public int MinimumNumberCount { get; set; } = 0;
}
