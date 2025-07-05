namespace DiffCode.Validating.Interfaces;

/// <summary>
/// Интерфейс набора предикатов для проверки условий из категории "МНОЖЕСТВО VS. ЭЛЕМЕНТ"
/// (проверяемое множество элементов сопоставляется с одним значением).
/// </summary>
public interface IFuncsManyOne
{


  /// МНОЖЕСТВО VS. ЭЛЕМЕНТ
  /// <summary>
  /// Коллекция элементов many включает в себя уникальный в ее пределах элемент one.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public Func<IEnumerable<T>, T, bool> UniqueOneInMany<T>() => (many, one) => (many?.Count(w => w != null && w.Equals(one)) ?? 0) == 1;


  /// МНОЖЕСТВО VS. ЭЛЕМЕНТ
  /// <summary>
  /// Коллекция элементов many включает в себя элемент one в качестве первого по счету элемента.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="firstOne"></param>
  /// <returns></returns>
  public Func<IEnumerable<T>, T, bool> FirstOneInMany<T>() => (many, firstOne) => many?.FirstOrDefault()?.Equals(firstOne) ?? false;


  /// МНОЖЕСТВО VS. ЭЛЕМЕНТ
  /// <summary>
  /// Коллекция элементов many включает в себя элемент one в качестве последнего по счету элемента.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="lastOne"></param>
  /// <returns></returns>
  public Func<IEnumerable<T>, T, bool> LastOneInMany<T>() => (many, lastOne) => many?.LastOrDefault()?.Equals(lastOne) ?? false;



  public Func<IEnumerable<T>, T, bool> OneCountOfMany<T>(int one) => (many, _) => (many?.Count() ?? 0) == one;


}
