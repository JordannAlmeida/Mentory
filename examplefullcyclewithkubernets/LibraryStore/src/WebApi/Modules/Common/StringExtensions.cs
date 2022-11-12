namespace WebApi.Modules.Common
{
    public static class StringExtensions
    {
        public static string Remove(this string text, string textToRemove) => text.Replace(textToRemove, "");
    }
}