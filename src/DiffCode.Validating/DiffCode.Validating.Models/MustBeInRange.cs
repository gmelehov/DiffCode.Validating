using DiffCode.Validating.Abstractions;
using DiffCode.Validating.Interfaces;
using FluentValidation;
using System.Numerics;


namespace DiffCode.Validating.Models;

/// <summary>
/// Правило валидации для значения, которое должно попадать в установленный интервал.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="V"></typeparam>
public record MustBeInRange<T, V> : BaseOneOne<T, V> where T : IValidatable<T> where V : struct, INumber<V>, IComparable<V>
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="elemExpr"><inheritdoc /></param>
  /// <param name="elemValExpr"><inheritdoc /></param>
  /// <param name="valExpr"><inheritdoc /></param>
  public MustBeInRange(Func<T> elemExpr, Func<T, V> elemValExpr, Func<(V, V)> valExpr) : base(elemExpr, elemValExpr, null)
  {
    ValueRange = valExpr;
  }





  public Func<(V, V)> ValueRange { get; }

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, V> CurrValueGetter => _elemValExpr;

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<V, V, bool> Fn => (this as IFuncsOneOne).OneInRange<V>(ValueRange().Item1, ValueRange().Item2);

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, ValidationContext<T>, string> ErrorMsg => (p, ctx)
    => $"Значение элемента {Element} ({CurrValue}) должно находиться в диапазоне от {ValueRange().Item1} до {ValueRange().Item2}";

}
