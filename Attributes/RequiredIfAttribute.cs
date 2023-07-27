using System;
using System.ComponentModel.DataAnnotations;

namespace WrestlingMVC.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string dependentPropertyName;
        private readonly object targetValue;

        public RequiredIfAttribute(string dependentPropertyName, object targetValue)
        {
            this.dependentPropertyName = dependentPropertyName;
            this.targetValue = targetValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dependentProperty = validationContext.ObjectType.GetProperty(dependentPropertyName);
            if (dependentProperty == null)
            {
                return new ValidationResult($"Property '{dependentPropertyName}' not found.");
            }

            var dependentPropertyValue = dependentProperty.GetValue(validationContext.ObjectInstance);
            if (dependentPropertyValue == null || !dependentPropertyValue.Equals(targetValue))
            {
                return ValidationResult.Success;
            }

            return value == null ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
        }
    }
}
