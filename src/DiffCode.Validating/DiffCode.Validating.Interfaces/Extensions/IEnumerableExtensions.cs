namespace DiffCode.Validating.Interfaces.Extensions;

/// <summary>
/// Методы расширения для объектов, реализующих интерфейс <see cref="IEnumerable{T}"/>.
/// </summary>
public static class IEnumerableExtensions
{



  public static string AsString<T>(this IEnumerable<T> values, string delimiter = "; ")
  {
    return string.Join(delimiter, values.Select(s => s.ToString()).ToArray());
  }



}