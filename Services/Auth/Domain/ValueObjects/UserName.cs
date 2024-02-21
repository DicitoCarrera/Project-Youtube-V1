using Domain.Abstractions;

namespace Domain.ValueObjects;

public readonly record struct UserName
{
    private UserName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<UserName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 20)
            return new Error("Username.InvalidLength", "The username must be between 3 and 20 characters");

        return new UserName(value);
    }

    public static implicit operator string(UserName self)
    {
        return self.Value;
    }
}