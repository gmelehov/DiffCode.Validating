using DiffCode.Validating.Abstractions;
using DiffCode.Validating.Interfaces;
using DiffCode.Validating.Interfaces.Extensions;
using FluentValidation;


namespace DiffCode.Validating.Models;

/// <summary>
/// Правило валидации для списка, который должен содержать установленное значение, уникальное в пределах этого списка.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="V"></typeparam>
public record MustContainUniqueItem<T, V> : BaseManyOne<T, V> where T : IValidatable<T>
{
  /// <summary>
  /// <inheritdoc />
  /// </summary>
  /// <param name="elemExpr"></param>
  /// <param name="elemValExpr"></param>
  /// <param name="valExpr"></param>
  public MustContainUniqueItem(Func<T> elemExpr, Func<T, IEnumerable<V>> elemValExpr, Func<V> valExpr) : base(elemExpr, elemValExpr, valExpr)
  {

  }





  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, IEnumerable<V>> CurrValuesGetter => _elemValExpr;

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<IEnumerable<V>, V, bool> Fn => (this as IFuncsManyOne).UniqueOneInMany<V>();

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, ValidationContext<T>, string> ErrorMsg => (p, ctx)
    => $"Элемент {Value} должен быть уникальным (встречаться ровно один раз) в пределах списка значений элемента {Element} ({CurrValues.AsString()}).";

}
