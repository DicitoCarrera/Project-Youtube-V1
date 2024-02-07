using System.Text.RegularExpressions;

namespace Core.Entities;

public readonly record struct EmailAddress
{
    private readonly string value;

    private EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^\S+@\S+\.\S+$"))
        {
            throw new ArgumentException("Invalid email address format.", nameof(value));
        }

        this.value = value;
    }

    public static EmailAddress Create(string emailAddress) => new EmailAddress(emailAddress);

    public override string ToString() => value;
}