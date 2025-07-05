namespace DiffCode.Validating.Interfaces;

/// <summary>
/// Интерфейс набора предикатов для проверки условий из категории "ЭЛЕМЕНТ VS. МНОЖЕСТВО"
/// (проверяемый элемент сопоставляется с множеством элементов).
/// </summary>
public interface IFuncsOneMany
{


  /// ЭЛЕМЕНТ VS. МНОЖЕСТВО
  /// <summary>
  /// Элемент включен в коллекцию many.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="many"></param>
  /// <returns></returns>
  public Func<T, IEnumerable<T>, bool> OneInMany<T>() => (one, many) => many.Any(p => p.Equals(one));


  /// ЭЛЕМЕНТ VS. МНОЖЕСТВО
  /// <summary>
  /// Элемент не включен в коллекцию many.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="many"></param>
  /// <returns></returns>
  public Func<T, IEnumerable<T>, bool> OneNotInMany<T>() => (one, many) => !many.Any(p => p.Equals(one));

}
