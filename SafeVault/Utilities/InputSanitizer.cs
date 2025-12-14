// Utilities/InputSanitizer.cs
using System.Text.RegularExpressions;

public static class InputSanitizer
{
    public static string SanitizeUsername(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        // Allow letters, numbers, underscore
        return Regex.Replace(input, @"[^\w]", string.Empty);
    }

    public static string SanitizeEmail(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        // Basic email validation
        if (!Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            return string.Empty;

        return input;
    }
}
