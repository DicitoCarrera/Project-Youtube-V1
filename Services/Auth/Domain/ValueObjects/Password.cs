namespace Domain.ValueObjects;

public readonly record struct Password
{
    private Password(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Password Create(string value)
    {
        // Example validation criteria: minimum 8 characters, at least one number, one letter, and one special character
        if (string.IsNullOrWhiteSpace(value) || value.Length < 8)
            throw new ArgumentException(
                "The password must be at least 8 characters", nameof(value));

        if (!value.Any(char.IsDigit) || !value.Any(char.IsLetter) ||
            value.All(char.IsLetterOrDigit))
            throw new ArgumentException(
                "The password must contain at least one number, one letter, and one special character",
                nameof(value));

        return new Password(value);
    }
}