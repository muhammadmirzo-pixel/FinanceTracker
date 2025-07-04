using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Domain.Attributes;

public sealed class LocalPhoneAttribute : RegularExpressionAttribute
{
    public LocalPhoneAttribute() 
        : base("^\\+998([-| ])?(90|91|93|94|95|98|99|33|97|71|77|20|88|33|75|50)([-|])?(\\d{3})([-| ])?(\\d{2})([-| ])?(\\d{2}) $") 
    { 
        this.ErrorMessage = "The phone number must be in the format +998 (XX) XXX-XX-XX, where XX is a valid Uzbek mobile operator code.";
    }
}