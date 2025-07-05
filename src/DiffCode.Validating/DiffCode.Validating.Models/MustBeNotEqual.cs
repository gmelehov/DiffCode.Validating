using DiffCode.Validating.Abstractions;
using DiffCode.Validating.Interfaces;
using FluentValidation;


namespace DiffCode.Validating.Models;

/// <summary>
/// Правило валидации для значения, которое не должно быть равно заданному.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="V"></typeparam>
public record MustBeNotEqual<T, V> : BaseOneOne<T, V> where T : IValidatable<T>
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="elemExpr"><inheritdoc /></param>
  /// <param name="elemValExpr"><inheritdoc /></param>
  /// <param name="valExpr"><inheritdoc /></param>
  public MustBeNotEqual(Func<T> elemExpr, Func<T, V> elemValExpr, Func<V> valExpr) : base(elemExpr, elemValExpr, valExpr)
  {

  }



  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, V> CurrValueGetter => _elemValExpr;

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<V, V, bool> Fn => (this as IFuncsOneOne).OneNotEqualsOther<V>();

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, ValidationContext<T>, string> ErrorMsg => (p, ctx)
    => $"Значение элемента {Element} ({CurrValue}) не должно быть равно заданному - {Value}";

}
