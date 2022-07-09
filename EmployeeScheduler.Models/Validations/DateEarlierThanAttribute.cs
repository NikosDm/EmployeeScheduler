using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeScheduler.Models.Validations;

/*
Data Annotation which is used for validating two dates. 
More specifically it validates whether a date is earlier than another or not.
*/
public class DateEarlierThanAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public DateEarlierThanAttribute(string comparisonProperty)
    {
         _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        ErrorMessage = ErrorMessageString;
        var currentValue = (DateTime)value;

        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

        if (property == null)
            throw new ArgumentException("Property with this name not found");

        var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

        if (currentValue > comparisonValue)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}
