using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DemoValidation
{
  internal class DataAnnotationValidator
  {
    internal static Dictionary<string, List<string>> GetErrors(object validationSource)
    {
      Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
      Type type = validationSource.GetType();
      PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.GetField | BindingFlags.Instance);
      return properties.ToDictionary(p => p.Name, p => GetFieldErrors(validationSource, p));
    }
    private static List<string> GetFieldErrors(object validationSource, PropertyInfo property)
    {
      var propertyValue = property.GetValue(validationSource);
      List<ValidationResult> results = new List<ValidationResult>();
      bool result = Validator.TryValidateProperty(
          propertyValue,
          new ValidationContext(validationSource, null, null)
          {
            MemberName = property.Name
          },
          results);
      return results.Select(vr => vr.ErrorMessage)
                 .OfType<string>()
                 .ToList();
    }
  }
}
