using Microsoft.Extensions.Configuration;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Создаем конфигурацию и загружаем настройки из appsettings.json
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())  // Устанавливаем базовый путь
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);  // Добавляем JSON файл конфигурации

        IConfiguration config = builder.Build();

        // Получаем настройку ApplicationName из конфигурации
        string appName = config["AppSettings:ApplicationName"] ?? "DefaultAppName";
        Console.WriteLine($"Application Name: {appName}");
    }
}
