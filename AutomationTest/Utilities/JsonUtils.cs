using System.IO;
using System.Text.Json;
using AutomationTest.Models;

namespace AutomationTest.Utilities
{
    public static class JsonUtils
    {
        public static FormData GetFormData(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<FormData>(jsonContent);
        }
    }
}