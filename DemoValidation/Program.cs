// See https://aka.ms/new-console-template for more information
using DemoValidation;




var contact = new Contact { Name = "", FirstName="Emmanuel", Age=110 };

Dictionary<string, List<string>> errors = DataAnnotationValidator.GetErrors(contact);

Console.WriteLine("Hello, World!");