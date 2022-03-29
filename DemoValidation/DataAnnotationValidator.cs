using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DemoValidation
{
  internal class DataAnnotationValidator
  {
    internal static Dictionary<string, List<string>> GetErrors(Object validationSource)
    {
      Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
      Type type = validationSource.GetType();
      PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.GetField | BindingFlags.Instance);
      foreach (var property in properties)
      {
        var propertyName = property.Name;

        //string error = string.Empty;
        var propertyValue = property.GetValue(validationSource);
        var results = new List<ValidationResult>(1);
        var result = Validator.TryValidateProperty(
            propertyValue,
            new ValidationContext(validationSource, null, null)
            {
              MemberName = propertyName
            },
            results);
        if (!result)
        {
          var validationResult = results.First();
          errors.Add(propertyName,
            results
                .Select(vr => vr.ErrorMessage)
                .OfType<string>()
                .ToList());
        }
      }
      return errors;
    }
  }
}
