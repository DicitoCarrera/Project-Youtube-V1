namespace Core.Entities;

public readonly record struct UserName
{
    private readonly string value;

    private UserName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 20)
        {
            throw new ArgumentException("Username must be between 3 and 20 characters long.", nameof(value));
        }

        this.value = value;
    }

    public static UserName Create(string userName) => new UserName(userName);

    public override string ToString() => value;
}