using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinanceTracker.Service.Errors;

public static class UserErrors
{
    public static readonly Error UserNotFound = Error.NotFound(
        "User.UserNotFound");

    public static readonly Error UserAlreadyExists = Error.Validation(
        "User.UserAlreadyExists");

    public static readonly Error PinflAlreadyExists = Error.Validation(
        "User.PinflAlreadyExists");

    public static readonly Error UsernameAlreadyExists = Error.Validation(
        "User.UsernameAlreadyExists");
    public static readonly Error PhoneNumberAlreadyExists = Error.Validation(
        "User.PhoneNumberAlreadyExists");
    public static readonly Error InvalidPassword = Error.Validation(
        "User.InvalidPassword");

}
