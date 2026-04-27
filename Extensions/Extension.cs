using MyApp.Models;

namespace MyApp.Extensions
{
    public static class Extension
    {
        public static string ToUpperName(this ExtensionField extensionField)
        {
            return extensionField.Name.ToUpper(); // Example of an extension method that converts the Name property to uppercase
        }
    }
}
