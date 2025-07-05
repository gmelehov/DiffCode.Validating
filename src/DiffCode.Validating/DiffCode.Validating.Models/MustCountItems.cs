using DiffCode.Validating.Abstractions;
using DiffCode.Validating.Interfaces;
using DiffCode.Validating.Interfaces.Extensions;
using FluentValidation;


namespace DiffCode.Validating.Models;

/// <summary>
/// Правило валидации для количества элементов в списке, 
/// которое должно быть равно установленному значению.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="V"></typeparam>
public record MustCountItems<T, V> : BaseManyOne<T, V> where T : IValidatable<T>
{
  /// <summary>
  /// <inheritdoc />
  /// </summary>
  /// <param name="elemExpr"></param>
  /// <param name="elemValExpr"></param>
  /// <param name="valExpr"></param>
  public MustCountItems(Func<T> elemExpr, Func<T, IEnumerable<V>> elemValExpr, Func<int> valExpr) : base(elemExpr, elemValExpr, null)
  {
    ItemsCount = valExpr;
  }





  public Func<int> ItemsCount {  get; }

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, IEnumerable<V>> CurrValuesGetter => _elemValExpr;

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<IEnumerable<V>, V, bool> Fn => (this as IFuncsManyOne).OneCountOfMany<V>(ItemsCount());

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, ValidationContext<T>, string> ErrorMsg => (p, ctx)
    => $"Список значений элемента {Element} ({CurrValues.AsString()}) должен содержать установленное количество значений - {ItemsCount()}";

}
