namespace Domain.ValueObjects;

public readonly record struct EmailAddress
{
    private EmailAddress(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static EmailAddress Create(string value)
    {
        // Basic validation to check if the email contains '@'
        if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
            throw new ArgumentException("The email address is not valid",
                nameof(value));

        return new EmailAddress(value);
    }
}