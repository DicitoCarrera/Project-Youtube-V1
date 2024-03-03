using Domain.Abstractions;

namespace Application.Errors;

public sealed class AuthErrors
{
    public static readonly Error InvalidCredentials
        = new(Code: "InvalidCredentials", Description: "Invalid credentials"
        );

    public static readonly Error InvalidEmail
        = new(Code: "InvalidEmail", Description: "Invalid email address");

    public static readonly Error InvalidPassword
        = new("InvalidPassword", "Invalid password");

    public static readonly Error UserNotFound
        = new("UserNotFound", "User not found");

    public static readonly Error UserAlreadyExists
        = new("UserAlreadyExists", "User already exists");

    public static readonly Error InvalidToken
        = new("InvalidToken", "Invalid token");

    public static readonly Error UserDisabled
        = new("UserDisabled", "User disabled");

    public static readonly Error UserLocked
        = new("UserLocked", "User locked");

    public static readonly Error UserNotVerified
        = new("UserNotVerified", "User not verified");

    public static readonly Error UserAlreadyVerified
        = new("UserAlreadyVerified", "User already verified");

    public static readonly Error UserNotActive
        = new("UserNotActive", "User not active");

    public static readonly Error UserAlreadyActive
        = new("UserAlreadyActive", "User already active");
}