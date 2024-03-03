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
        if (string.IsNullOrWhiteSpace(value: value) || value.Length < 8)
            throw new ArgumentException("The password must be at least 8 characters", paramName: nameof(value));

        if (!value.Any(predicate: char.IsDigit) || !value.Any(predicate: char.IsLetter) || value.All(predicate: char.IsLetterOrDigit))
            throw new ArgumentException(
                "The password must contain at least one number, one letter, and one special character", paramName: nameof(value));

        return new Password(value: value);
    }
}