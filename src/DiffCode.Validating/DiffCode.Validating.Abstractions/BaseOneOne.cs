using DiffCode.Validating.Interfaces;
using FluentValidation;
using System.Diagnostics;
using System.Linq.Expressions;


namespace DiffCode.Validating.Abstractions;

/// <summary>
/// Базовая модель настройки правила валидации для элемента по схеме "ЭЛЕМЕНТ VS ЭЛЕМЕНТ".
/// Тип валидации - сопоставление текущего значения (<see cref="CurrValue"/>) с целевым значением (<see cref="BaseTCaseOne{T, V}.Value"/>).
/// </summary>
/// <typeparam name="T">Тип элемента, к которому относится это правило.</typeparam>
/// <typeparam name="V">Тип целевого и текущего значения.</typeparam>
public abstract record BaseOneOne<T, V> : BaseTCaseOne<T, V>, IFuncsOneOne where T : IValidatable<T>
{
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  protected Func<T, V> _elemValExpr;



  /// <summary>
  /// 
  /// </summary>
  /// <param name="elemExpr">Выражение для возврата валидируемого элемента.</param>
  /// <param name="elemValExpr">Выражение для возврата текущего значения из валидируемого элемента.</param>
  /// <param name="valExpr">Выражение для возврата целевого значения, с которым будет сравниваться значение, полученное из <paramref name="elemValExpr"/>.</param>
  protected BaseOneOne(Func<T> elemExpr, Func<T, V> elemValExpr, Func<V> valExpr) : base(elemExpr, valExpr)
  {
    _elemValExpr = elemValExpr;
  }




  /// <summary>
  /// Предикат для получения значения, которое необходимо валидировать.
  /// </summary>
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  public abstract Func<T, V> CurrValueGetter { get; }

  /// <summary>
  /// Текущее значение, которое будет сопоставляться с целевым значением (<see cref="TCaseOne{T, TVal}.Value"/>).
  /// </summary>
  public V CurrValue => CurrValueGetter != null ? CurrValueGetter.Invoke((T)Element) : default(V);

  /// <summary>
  /// Предикат для проверки.
  /// </summary>
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  public abstract Func<V, V, bool> Fn { get; }

  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  public override Action<T, ValidationContext<T>> Action => (p, ctx) =>
  {
    Element ??= p;
    if (!Fn(CurrValueGetter(p), Value))
    {
      var failure = GetValidationFailure(ErrorMsg?.Invoke(p, ctx));
      ProcessValidationResult(ctx, failure);
    }
  };
}
