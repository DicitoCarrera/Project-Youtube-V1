using Domain.Abstractions;

namespace Domain.ValueObjects;

public readonly record struct Password
{
    private Password(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Password> Create(string value)
    {
        // Example validation criteria: minimum 8 characters, at least one number, one letter, and one special character
        if (string.IsNullOrWhiteSpace(value) || value.Length < 8)
            return new Error("Password.InvalidLength", "The password must be at least 8 characters");

        if (!value.Any(char.IsDigit) || !value.Any(char.IsLetter) || value.All(char.IsLetterOrDigit))
            return new Error("Password.Complexity",
                "The password must contain at least one number, one letter, and one special character");

        return new Password(value);
    }

    public static implicit operator string(Password password)
    {
        return password.Value;
    }
}