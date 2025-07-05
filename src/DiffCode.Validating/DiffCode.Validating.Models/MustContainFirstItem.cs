using DiffCode.Validating.Abstractions;
using DiffCode.Validating.Interfaces;
using DiffCode.Validating.Interfaces.Extensions;
using FluentValidation;


namespace DiffCode.Validating.Models;

/// <summary>
/// Правило валидации для списка, первым элементом которого
/// должен являться заданный элемент.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="V"></typeparam>
public record MustContainFirstItem<T, V> : BaseManyOne<T, V> where T : IValidatable<T>
{
  /// <summary>
  /// <inheritdoc />
  /// </summary>
  /// <param name="elemExpr"></param>
  /// <param name="elemValExpr"></param>
  /// <param name="valExpr"></param>
  public MustContainFirstItem(Func<T> elemExpr, Func<T, IEnumerable<V>> elemValExpr, Func<V> valExpr) : base(elemExpr, elemValExpr, valExpr)
  {
    
  }





  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, IEnumerable<V>> CurrValuesGetter => _elemValExpr;

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<IEnumerable<V>, V, bool> Fn => (this as IFuncsManyOne).FirstOneInMany<V>();

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, ValidationContext<T>, string> ErrorMsg => (p, ctx)
    => $"Первым в списке значений элемента {Element} ({CurrValues.AsString()}) должно находиться установленное значение - {Value}.";

}
