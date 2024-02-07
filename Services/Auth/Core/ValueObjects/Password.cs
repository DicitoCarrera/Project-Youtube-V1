namespace Core.Entities;

public readonly record struct Password
{
    private readonly string value;

    private Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 12)
        {
            throw new ArgumentException("Password must be at least 8 characters long.", nameof(value));
        }

        // Add more complexity checks as needed here

        this.value = value;
    }

    public static Password Create(string password) => new Password(password);

    public string Hashed => HashPassword(value);

    private static string HashPassword(string password)
    {
        // Implement password hashing here
        return password; // Placeholder
    }
}