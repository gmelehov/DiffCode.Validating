using DiffCode.Validating.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;


namespace DiffCode.Validating.Abstractions;

/// <summary>
/// Базовая модель настройки правила валидации по схеме "ЭЛЕМЕНТ/МНОЖЕСТВО VS МНОЖЕСТВО".
/// По этой схеме выполняются все валидации, связанные с сопоставлением одного или нескольких значений с целевым множеством значений (<see cref="Values"/>).
/// </summary>
/// <typeparam name="T">Тип элемента, к которому относится это правило.</typeparam>
/// <typeparam name="V">Тип значения в целевом списке/текущего значения/элемента в текущем списке значений.</typeparam>
public abstract record BaseTCaseMany<T, V> : BaseTCase<T> where T : IValidatable<T>
{
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  protected Func<IEnumerable<V>> _valFn;




  protected BaseTCaseMany(Func<T> elemExpr, Func<IEnumerable<V>> valExpr) : base()
  {
    _valFn = valExpr;
    Lambda = elemExpr;
  }



  /// <summary>
  /// Список целевых значений, с которым будет сопоставляться текущее значений/список значений при валидации элемента.
  /// </summary>
  [DebuggerDisplay("{ToList()")]
  public List<V> Values => _valFn.Invoke().ToList();
}
