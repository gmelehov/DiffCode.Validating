namespace DiffCode.Validating.Interfaces;

/// <summary>
/// Интерфейс набора предикатов для проверки условий из категории "МНОЖЕСТВО VS. МНОЖЕСТВО"
/// (проверяемое множество элементов сопоставляется с другим множеством элементов).
/// </summary>
public interface IFuncsManyMany
{


  /// МНОЖЕСТВО VS. МНОЖЕСТВО
  /// <summary>
  /// Коллекция many включает в себя некоторые элементы из коллекции any.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public Func<IEnumerable<T>, IEnumerable<T>, bool> ManyIncludesAny<T>() => (many, any) => any.Any(p => many.Contains(p));


  /// МНОЖЕСТВО VS. МНОЖЕСТВО
  /// <summary>
  /// Коллекция many соответствует коллекции other.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public Func<IEnumerable<T>, IEnumerable<T>, bool> ManyEqualsOther<T>() => (many, other) => many.SequenceEqual(other);


  /// МНОЖЕСТВО VS. МНОЖЕСТВО
  /// <summary>
  /// Коллекция many не включает в себя ни одного элемента из коллекции any.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public Func<IEnumerable<T>, IEnumerable<T>, bool> ManyNotIncludesAny<T>() => (many, any) => !any.Any(p => many.Contains(p));


  /// МНОЖЕСТВО VS. МНОЖЕСТВО
  /// <summary>
  /// Коллекция many включает в себя все элементы из коллекции all.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public Func<IEnumerable<T>, IEnumerable<T>, bool> ManyIncludesAll<T>() => (many, all) => all.All(p => many.Contains(p));


}
