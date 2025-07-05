using DiffCode.Validating.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;


namespace DiffCode.Validating.Abstractions;

/// <summary>
/// Базовая модель настройки правила валидации по схеме "ЭЛЕМЕНТ/МНОЖЕСТВО VS ЭЛЕМЕНТ".
/// По этой схеме выполняются все валидации, связанные с сопоставлением одного или нескольких значений с одним целевым (<see cref="Value"/>).
/// </summary>
/// <typeparam name="T">Тип элемента, к которому относится это правило.</typeparam>
/// <typeparam name="V">Тип целевого значения/текущего значения/элемента в текущем списке значений.</typeparam>
public abstract record BaseTCaseOne<T, V> : BaseTCase<T> where T : IValidatable<T>
{
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  protected Func<V> _valFn;




  protected BaseTCaseOne(Func<T> elemExpr, Func<V> valExpr) : base()
  {
    _valFn = valExpr;
    Lambda = elemExpr;
  }




  /// <summary>
  /// Целевое значение, с которым будет сопоставляться текущее при валидации элемента.
  /// </summary>
  public V Value => _valFn != null ? _valFn.Invoke() : default;

}
