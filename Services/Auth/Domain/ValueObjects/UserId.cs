namespace Domain.ValueObjects;

public readonly record struct UserId(Guid Value)
{
    public static UserId NewUserId()
    {
        return new UserId(Guid.NewGuid());
    }

    public static implicit operator Guid(UserId self)
    {
        return self.Value;
    }
}