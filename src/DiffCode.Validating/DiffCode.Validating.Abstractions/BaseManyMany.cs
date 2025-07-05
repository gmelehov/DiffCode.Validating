using DiffCode.Validating.Interfaces;
using FluentValidation;
using System.Diagnostics;
using System.Linq.Expressions;


namespace DiffCode.Validating.Abstractions;

/// <summary>
/// Базовая модель настройки правила валидации для элемента по схеме "МНОЖЕСТВО VS МНОЖЕСТВО".
/// Тип валидации - сопоставление текущего списка значений (<see cref="CurrValues"/>) с целевым списком (<see cref="BaseTCaseMany{T, TVal}.Values"/>).
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="V"></typeparam>
public abstract record BaseManyMany<T, V> : BaseTCaseMany<T, V>, IFuncsManyMany where T : IValidatable<T>
{
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  protected Func<T, IEnumerable<V>> _elemValExpr;



  /// <summary>
  /// 
  /// </summary>
  /// <param name="elemExpr">Выражение для возврата валидируемого элемента.</param>
  /// <param name="elemValExpr">Выражение для возврата списка текущих значений из валидируемого элемента.</param>
  /// <param name="valExpr">Выражение для возврата целевого списка значений, с которым будет сравниваться список значений, полученный из <paramref name="elemValExpr"/>.</param>
  protected BaseManyMany(Func<T> elemExpr, Func<T, IEnumerable<V>> elemValExpr, Func<IEnumerable<V>> valExpr) : base(elemExpr, valExpr)
  {
    _elemValExpr = elemValExpr;
  }




  /// <summary>
  /// Предикат для получения значения, которое необходимо валидировать.
  /// </summary>
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  public abstract Func<T, IEnumerable<V>> CurrValuesGetter { get; }

  /// <summary>
  /// Текущее значение, которое будет сопоставляться с целевым значением (<see cref="BaseTCaseMany{T, TVal}.Values"/>).
  /// </summary>
  public IEnumerable<V> CurrValues => Element != null ? CurrValuesGetter?.Invoke((T)Element) : null;

  /// <summary>
  /// Предикат для проверки.
  /// </summary>
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  public abstract Func<IEnumerable<V>, IEnumerable<V>, bool> Fn { get; }

  /// <summary>
  /// <inheritdoc/>
  /// </summary>
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  public override Action<T, ValidationContext<T>> Action => (p, ctx) =>
  {
    Element ??= p;
    if (!Fn(CurrValuesGetter(p), Values))
    {
      var failure = GetValidationFailure(ErrorMsg?.Invoke(p, ctx));
      ProcessValidationResult(ctx, failure);
    }
  };
}