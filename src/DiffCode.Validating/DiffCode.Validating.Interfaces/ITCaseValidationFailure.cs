using FluentValidation;


namespace DiffCode.Validating.Interfaces;

/// <summary>
/// Интерфейс сообщения об ошибке валидации.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ITCaseValidationFailure<T> where T : IValidatable<T>
{

  /// <summary>
	/// The error message
	/// </summary>
	string ErrorMessage { get; set; }

  /// <summary>
  /// The property value that caused the failure.
  /// </summary>
  object AttemptedValue { get; set; }

  /// <summary>
  /// Custom state associated with the failure.
  /// </summary>
  object CustomState { get; set; }

  /// <summary>
  /// Custom severity level associated with the failure.
  /// </summary>
  Severity Severity { get; set; }

  /// <summary>
  /// Gets or sets the error code.
  /// </summary>
  string ErrorCode { get; set; }

  /// <summary>
  /// Ссылка на настройки правила валидации, которые вызвали ошибку.
  /// </summary>
  ITCase<T> TCase { get; }

}
