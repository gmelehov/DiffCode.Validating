using DiffCode.Validating.Interfaces;
using FluentValidation;
using System.Diagnostics;
using System.Linq.Expressions;


namespace DiffCode.Validating.Abstractions;

/// <summary>
/// Базовая модель настройки правила валидации для элемента по схеме "МНОЖЕСТВО VS ЭЛЕМЕНТ".
/// Тип валидации - сопоставление текущего списка значений (<see cref="CurrValues"/>) с целевым значением (<see cref="BaseTCaseOne{T, V}.Value"/>).
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="V"></typeparam>
public abstract record BaseManyOne<T, V> : BaseTCaseOne<T, V>, IFuncsManyOne where T : IValidatable<T>
{
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  protected Func<T, IEnumerable<V>> _elemValExpr;



  /// <summary>
  /// 
  /// </summary>
  /// <param name="elemExpr">Выражение для возврата валидируемого элемента.</param>
  /// <param name="elemValExpr">Выражение для возврата списка текущих значений из валидируемого элемента.</param>
  /// <param name="valExpr">Выражение для возврата целевого значения, с которым будет сравниваться список значений, полученный из <paramref name="elemValExpr"/>.</param>
  protected BaseManyOne(Func<T> elemExpr, Func<T, IEnumerable<V>> elemValExpr, Func<V> valExpr) : base(elemExpr, valExpr)
  {
    _elemValExpr = elemValExpr;
  }




  /// <summary>
  /// Предикат для получения значения, которое необходимо валидировать.
  /// </summary>
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  public abstract Func<T, IEnumerable<V>> CurrValuesGetter { get; }

  /// <summary>
  /// Текущее значение, которое будет сопоставляться с целевым значением (<see cref="BaseTCaseOne{T, TVal}.Value"/>).
  /// </summary>
  public IEnumerable<V> CurrValues => Element != null ? CurrValuesGetter?.Invoke((T)Element) : null;

  /// <summary>
  /// Предикат для проверки.
  /// </summary>
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  public abstract Func<IEnumerable<V>, V, bool> Fn { get; }

  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  public override Action<T, ValidationContext<T>> Action => (p, ctx) =>
  {
    Element ??= p;
    if (!Fn(CurrValuesGetter(p), Value))
    {
      var failure = GetValidationFailure(ErrorMsg?.Invoke(p, ctx));
      ProcessValidationResult(ctx, failure);
    }
  };
}
