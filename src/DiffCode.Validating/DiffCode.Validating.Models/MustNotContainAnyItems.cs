using DiffCode.Validating.Abstractions;
using DiffCode.Validating.Interfaces;
using DiffCode.Validating.Interfaces.Extensions;
using FluentValidation;


namespace DiffCode.Validating.Models;

/// <summary>
/// Правило валидации для списка, который не должен содержать ни одного из 
/// элементов из заданного списка.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="V"></typeparam>
public record MustNotContainAnyItems<T, V> : BaseManyMany<T, V> where T : IValidatable<T>
{
  /// <summary>
  /// <inheritdoc />
  /// </summary>
  /// <param name="elemExpr"></param>
  /// <param name="elemValExpr"></param>
  /// <param name="valExpr"></param>
  public MustNotContainAnyItems(Func<T> elemExpr, Func<T, IEnumerable<V>> elemValExpr, Func<IEnumerable<V>> valExpr) : base(elemExpr, elemValExpr, valExpr)
  {

  }





  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, IEnumerable<V>> CurrValuesGetter => _elemValExpr;

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<IEnumerable<V>, IEnumerable<V>, bool> Fn => (this as IFuncsManyMany).ManyNotIncludesAny<V>();

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, ValidationContext<T>, string> ErrorMsg => (p, ctx)
    => $"Список значений элемента {Element} ({CurrValues.AsString()}) не должен содержать ни одного значения из установленного списка - {Values.AsString()}.";

}
