using DiffCode.Validating.Abstractions;
using DiffCode.Validating.Interfaces;
using DiffCode.Validating.Interfaces.Extensions;
using FluentValidation;


namespace DiffCode.Validating.Models;

/// <summary>
/// Правило валидации для значения, которое не должно содержаться в заданном списке.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="V"></typeparam>
public record MustBeNotEnlisted<T, V> : BaseOneMany<T, V> where T : IValidatable<T>
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="elemExpr"><inheritdoc /></param>
  /// <param name="elemValExpr"><inheritdoc /></param>
  /// <param name="valExpr"><inheritdoc /></param>
  public MustBeNotEnlisted(Func<T> elemExpr, Func<T, V> elemValExpr, Func<IEnumerable<V>> valExpr) : base(elemExpr, elemValExpr, valExpr)
  {

  }



  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, V> CurrValueGetter => _elemValExpr;

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<V, IEnumerable<V>, bool> Fn => (this as IFuncsOneMany).OneNotInMany<V>();

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, ValidationContext<T>, string> ErrorMsg => (p, ctx)
    => $"Значение элемента {Element} ({CurrValue}) не должно содержаться в установленном списке значений - {Values.AsString()}";

}
