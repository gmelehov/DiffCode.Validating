using DiffCode.Validating.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics;
using System.Threading.Tasks;


namespace DiffCode.Validating.Abstractions;

/// <summary>
/// Базовая модель валидатора.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseElementValidator<T> : AbstractValidator<T>, IWithFluentAction where T : IValidatable<T>
{
  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  protected List<ITCase<T>> _tcases = [];

  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
  protected List<ITCase<T>> _processed = [];



  protected BaseElementValidator()
  {
    
  }
  protected BaseElementValidator(T element)
  {
    Element = element;
  }




  public void AddTCases(params ITCase<T>[] cases)
  {
    foreach (var c in cases)
      _tcases.Add(c);

    ProcessTCases();
  }

  public void ProcessTCase(ITCase<T> tCase) => RuleFor(t => (T)tCase.Lambda.DynamicInvoke()).Custom(tCase.Action).When(_ => tCase.When?.Compile().Invoke() ?? true);

  public void ProcessTCases()
  {
    var tcasesToProcess = _tcases.Where(p => !_processed.Contains(p));
    foreach (var tcase in tcasesToProcess)
    {
      ProcessTCase(tcase);
      ValidationResult = new ValidationResult([Validate((T)(tcase.Lambda.DynamicInvoke()))]);
      _processed.Add(tcase);
    }
  }

  public void Validate() => _processed.ForEach(p => ValidationResult = new ValidationResult([Validate((T)(p.Lambda.DynamicInvoke()))]));





  public T Element { get; }


  public ValidationResult ValidationResult { get; set; } = new();
}