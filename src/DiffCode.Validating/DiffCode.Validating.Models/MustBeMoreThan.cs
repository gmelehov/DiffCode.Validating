using DiffCode.Validating.Abstractions;
using DiffCode.Validating.Interfaces;
using FluentValidation;


namespace DiffCode.Validating.Models;

/// <summary>
/// Правило валидации для значения, которое должно быть больше заданного.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="V"></typeparam>
public record MustBeMoreThan<T, V> : BaseOneOne<T, V> where T : IValidatable<T> where V : IComparable<V>
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="elemExpr"><inheritdoc /></param>
  /// <param name="elemValExpr"><inheritdoc /></param>
  /// <param name="valExpr"><inheritdoc /></param>
  public MustBeMoreThan(Func<T> elemExpr, Func<T, V> elemValExpr, Func<V> valExpr) : base(elemExpr, elemValExpr, valExpr)
  {

  }



  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, V> CurrValueGetter => _elemValExpr;

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<V, V, bool> Fn => (this as IFuncsOneOne).OneMoreThanOther<V>();

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, ValidationContext<T>, string> ErrorMsg => (p, ctx)
    => $"Значение элемента {Element} ({CurrValue}) должно быть больше заданного - {Value}";

}
