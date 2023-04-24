using PasswordGeneratorGUI.Models;

namespace PasswordGeneratorGUI.Logic;
public static class RandomGeneratorLogic {
    public static PasswordModel model = new();
    private static Random _random = new();
    private static List<char> characters = new();
    private static List<char> specialChars = new();

    public static void SetRequirements() {
        if (model.MaximumLength <= model.MinimumLength) {
            model.MaximumLength = model.MinimumLength + 1;
        }
        if (model.MinimumLength <= model.MinimumSpecialCharacters) {
            model.MinimumSpecialCharacters = model.MinimumLength - 1;
            model.MinimumSpecialCharacters = (model.MinimumSpecialCharacters <= 0) ? 0 : model.MinimumSpecialCharacters;
        }
        if (model.MinimumLength <= model.MinimumNumbers) {
            model.MinimumNumbers = model.MinimumLength - 1;
            model.MinimumNumbers = (model.MinimumNumberCount <= 0) ? 0 : model.MinimumNumbers;
        }
        while ((model.MinimumNumbers + model.MinimumSpecialCharacters) >= model.MinimumLength) {
            model.MinimumNumbers = (model.MinimumNumbers <= 0) ? 0 : model.MinimumNumbers - 1;
            model.MinimumSpecialCharacters = (model.MinimumSpecialCharacters <= 0) ? 0 : model.MinimumSpecialCharacters - 1;
        }

        characters.Clear();
        specialChars.Clear();
        model.Password = "";
    }

    public static void NewPassword() {
        GetSpecialCharacters();
        SetCharacters();
        GeneratePassword();
    }

    private static void GetSpecialCharacters() {
        specialChars.Clear();
        model.AllowedSpecialCharacters = model.AllowedSpecialCharacters.Replace(" ", "");
        char[] delimiterChars = { ',', ';' };
        string[] chars = model.AllowedSpecialCharacters.Split(delimiterChars);
        foreach (string s in chars) {
            specialChars.Add(s[0]);
        }
    }

    private static void SetCharacters() {
        characters.Clear();

        for (int i = (int)'0'; i <= (int)'9'; i++) {
            characters.Add(((char)i));
        }
        for (int i = (int)'A'; i <= (int)'Z'; i++) {
            characters.Add(((char)i));
        }
        for (int i = (int)'a'; i <= (int)'z'; i++) {
            characters.Add(((char)i));
        }
        foreach (char c in specialChars) {
            characters.Add(c);
        }
    }

    private static void GeneratePassword() {
        int passwordLength = _random.Next(model.MinimumLength, model.MaximumLength);
        int listCount = characters.Count - 1;
        
        do {
            model.Password = "";
            model.SpecialCharacterCount = 0;
            model.MinimumNumberCount = 0;
            for (int i = 0; i < passwordLength; i++) {
                string temp = characters[_random.Next(0, listCount)].ToString();
                model.Password += temp;
                if (IsSpecialCharacter(temp)) {
                    model.SpecialCharacterCount++;
                }
                if (IsNumber(temp)) {
                    model.MinimumNumberCount++;
                }
            }
        } while (NotMeetingRequirements());
    }

    private static bool NotMeetingRequirements() {
        return (!((model.SpecialCharacterCount >= model.MinimumSpecialCharacters) && (model.MinimumNumberCount >= model.MinimumNumbers)));
    }

    private static bool IsSpecialCharacter(string input) {
        bool output = false;
        foreach (char c in specialChars) {
            if (c == input[0]) {
                output = true; 
                break;
            }
        }
        return output;
    }

    private static bool IsNumber(string input) {
        return ((int)input[0] > 47 && (int)input[0] < 58);
    }
}
