namespace TechIntegration.Core.Models;

public class StatusDictionary
{
    private static Dictionary<int, string> statusDict = new()
    {
        { 1, "Status1" },
        { 2, "Status2" },
        { 3, "Status3" }
    };

    public static Dictionary<int, string> Dictionary => statusDict;
}