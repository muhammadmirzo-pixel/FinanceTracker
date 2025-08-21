using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinanceTracker.Service.Errors;

public static class UserErrors
{
    public static readonly Error UserNotFound = Error.NotFound(
        "User.UserNotFound");

    public static readonly Error UserAlreadyExists = Error.Conflict(
        "User.UserAlreadyExists");

    public static readonly Error PinflAlreadyExists = Error.Conflict(
        "User.PinflAlreadyExists");

    public static readonly Error UsernameAlreadyExists = Error.Conflict(
        "User.UsernameAlreadyExists");
    
    public static readonly Error PhoneNumberAlreadyExists = Error.Conflict(
        "User.PhoneNumberAlreadyExists");
    
    public static readonly Error InvalidPassword = Error.Failure(
        "User.InvalidPassword");

    public static readonly Error EmailNotFound = Error.NotFound(
        "User.EmailNotFound");
}
