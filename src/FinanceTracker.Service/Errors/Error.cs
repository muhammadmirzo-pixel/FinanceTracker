using FinanceTracker.Domain.Enums;
using ProtoBuf;

namespace FinanceTracker.Service.Errors;

public class Error
{
    private Error(
        string code,
        ErrorType errorType)
    {
        Code = code;
        Type = errorType;
    }

    [ProtoMember(1)]
    public string Code { get; }

    [ProtoMember(2)]
    public ErrorType Type { get; }

    public static Error NotFound(string code) =>
        new(code, ErrorType.NotFound);

    public static Error Validation(string code) =>
        new(code, ErrorType.Validation);

    public static Error Conflict(string code) =>
        new(code, ErrorType.Conflict);

    public static Error Failure(string code) =>
        new(code, ErrorType.Failure);
}
