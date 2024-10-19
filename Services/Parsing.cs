using System.Text.RegularExpressions;

namespace Lab2.Services;

public class Parsing
{
  public static int ParseInt(int min, int max)
  {

    int ans = 1;
    bool valid = false;
    bool minmax = false;

    while (!valid && !minmax)
    {
      Console.Write("=>");
      var input = Console.ReadLine();
      if (input != null)
      {
        if (int.TryParse((string)input, out ans))
        {
          if (ans < min)
          {
            Console.WriteLine($"Ошибка: число должно быть больше или равно {min}");
          }
          else if (ans > max)
          {
            Console.WriteLine($"Ошибка: число должно быть меньше или равно {max}");
          }
          else
          {
            valid = true;
          }
        }
        else
        {
          Console.WriteLine("Ошибка: введено не число. Попробуйте снова.");
        }
      }
    }
    Console.WriteLine();
    return ans;
  }


  public static string ParseLine()
  {
    Console.Write("=>");
    while (true)
    {
      var input = Console.ReadLine();
      if (input != null)
      {
        Console.WriteLine();
        return input.Trim();
      }
      else
      {
        Console.WriteLine("Ошибка: пустая строка. Попробуйте снова.");
      }
    }
  }


  public static string ParseOne()
  {
    return ParseLine();
  }

  public static (string first, string second) ParseTwo()
  {
    string pattern = @"^([^,]+),\s*(.+)$";
    while (true)
    {
      var line = ParseLine();
      if (Regex.IsMatch(line, pattern))
      {
        Console.WriteLine();
        var words = line.Split(", ", StringSplitOptions.RemoveEmptyEntries);
        return (words.Length > 0 ? words[0] : string.Empty,
            words.Length > 1 ? words[1] : string.Empty);
      }
      Console.WriteLine("Ошибка: должно быть две строки, разделенные запятой");
    }
  }

  public static (string first, string second, string third) ParseThree()
  {
    string pattern = @"^([^,]+),\s*([^,]+),\s*(.+)$";
    while (true)
    {
      var line = ParseLine();
      if (Regex.IsMatch(line, pattern))
      {
        var words = line.Split(", ", StringSplitOptions.RemoveEmptyEntries);
        return (words.Length > 0 ? words[0] : string.Empty,
            words.Length > 1 ? words[1] : string.Empty,
            words.Length > 2 ? words[2] : string.Empty);
      }
      Console.WriteLine("Ошибка: должно быть три строки, разделённые запятыми");
    }
  }

}
