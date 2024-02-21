using System.Net.Mail;
using Domain.Abstractions;

namespace Domain.ValueObjects;

public readonly record struct EmailAddress
{
    private EmailAddress(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<EmailAddress> Create(string value)
    {
        var address = new MailAddress(value);

        if (address.Address != value)
            return new Error("Email.NotValid", "The email address is not valid");

        return new EmailAddress(value);
    }

    public static implicit operator string(EmailAddress email)
    {
        return email.Value;
    }
}