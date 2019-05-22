namespace EntityFrameworkCore.Data
{
    public interface IQPFormService
    {
        string GetFormNameByNetNames(string netContentName, string netFieldName);
        string ReplacePlaceholders(string text);
    }
}