using FluentValidation;
using System.Linq.Expressions;


namespace DiffCode.Validating.Interfaces;

/// <summary>
/// Интерфейс настроек правила валидации объекта.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ITCase<T> where T : IValidatable<T>
{


  ITCaseValidationFailure<T> GetValidationFailure(string msg);

  void SetElement(T elem);

  void ProcessValidationResult(ValidationContext<T> ctx, ITCaseValidationFailure<T> failure);



  /// <summary>
  /// Лямбда для доступа к элементу.
  /// </summary>
  Func<T> Lambda { get; }

  /// <summary>
  /// Действие, выполняемое при ошибке валидации по этому правилу.
  /// </summary>
  Action<T, ValidationContext<T>> Action { get; }

  /// <summary>
  /// Условие проведения валидации.
  /// </summary>
  Expression<Func<bool>> When { get; init; }

  /// <summary>
  /// Ссылка на объект, к которому относится правило валидации.
  /// </summary>
  T Element { get; }


  Func<T, ValidationContext<T>, string> ErrorMsg { get; }

}
