using System.ComponentModel.DataAnnotations;

namespace PasswordGeneratorGUI.Models;
public class PasswordModel {
    [Required]
    public string AllowedSpecialCharacters { get; set; } = "# @ $ % ^ ! * + = _";
    [Required]
    [Range(1, 99, ErrorMessage = "Must be at least 1.")]
    public int MinimumLength { get; set; } = 9;
    [Required]
    public int MaximumLength { get; set;} = 30;
    [Required]
    public int MinimumLowerCase { get; set; } = 1;
    [Required]
    public int MinimumUpperCase { get; set; } = 1;
    [Required]
    public int MinimumSpecialCharacters { get; set; } = 1;
    [Required]
    public int MinimumNumbers { get; set; } = 1;
    [Required]
    public string Password { get; set; } = "";

    public int LowerCaseCount { get; set; } = 0;
    public int UpperCaseCount { get; set; } = 0;
    public int SpecialCharacterCount { get; set; } = 0;
    public int NumberCount { get; set; } = 0;
    public bool MeetsRequirements { get { return MeetsMinimumSpecialCharacter && MeetsMinimumNumberCount && MeetsMinimumLowerCaseLetterCount && MeetsMinimumUpperCaseCount; } }

    private bool MeetsMinimumSpecialCharacter { get { return SpecialCharacterCount >= MinimumSpecialCharacters; } }
    private bool MeetsMinimumNumberCount { get {  return NumberCount >= MinimumNumbers; } }
    private bool MeetsMinimumLowerCaseLetterCount { get { return LowerCaseCount >= MinimumLowerCase; } }
    private bool MeetsMinimumUpperCaseCount { get { return UpperCaseCount >= MinimumUpperCase; } }
}
