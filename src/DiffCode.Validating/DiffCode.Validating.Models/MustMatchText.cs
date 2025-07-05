using DiffCode.Validating.Abstractions;
using DiffCode.Validating.Interfaces;
using FluentValidation;


namespace DiffCode.Validating.Models;

/// <summary>
/// Правило валидации для строки, которая должна соответствовать установленному паттерну.
/// </summary>
/// <typeparam name="T"></typeparam>
public record MustMatchText<T> : BaseOneOne<T, string> where T : IValidatable<T>
{
  /// <summary>
  /// <inheritdoc />
  /// </summary>
  /// <param name="elemExpr"></param>
  /// <param name="elemValExpr"></param>
  /// <param name="valExpr"></param>
  public MustMatchText(Func<T> elemExpr, Func<T, string> elemValExpr, Func<string> valExpr) : base(elemExpr, elemValExpr, valExpr)
  {

  }



  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, string> CurrValueGetter => _elemValExpr;

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<string, string, bool> Fn => (this as IFuncsOneOne).OneMatchesOther();

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public override Func<T, ValidationContext<T>, string> ErrorMsg => (p, ctx)
    => $"Значение элемента {Element} ({CurrValue}) должно соответствовать установленному паттерну - {Value}";

}
