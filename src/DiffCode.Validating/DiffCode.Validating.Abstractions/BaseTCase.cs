using DiffCode.Validating.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.Linq.Expressions;


namespace DiffCode.Validating.Abstractions;

/// <summary>
/// Базовая типизированная модель настройки правил валидации.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract record BaseTCase<T> : ITCase<T> where T : IValidatable<T>
{
  protected BaseTCase()
  {

  }




  /// <summary>
  /// <inheritdoc />
  /// </summary>
  /// <param name="msg"></param>
  /// <returns></returns>
  public ITCaseValidationFailure<T> GetValidationFailure(string msg) => new TCaseValidationFailure(this, msg);

  /// <summary>
  /// <inheritdoc />
  /// </summary>
  /// <param name="ctx"></param>
  /// <param name="failure"></param>
  public void ProcessValidationResult(ValidationContext<T> ctx, ITCaseValidationFailure<T> failure) => ctx.AddFailure((ValidationFailure)failure);
  
  /// <summary>
  /// <inheritdoc />
  /// </summary>
  /// <param name="elem"></param>
  public void SetElement(T elem) => Element = elem;
  



  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public Func<T> Lambda { get; set; }
  
  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public abstract Action<T, ValidationContext<T>> Action { get; }
  
  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public Expression<Func<bool>> When { get; init; }
  
  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public T Element { get; set; }
  
  /// <summary>
  /// <inheritdoc />
  /// </summary>
  public abstract Func<T, ValidationContext<T>, string> ErrorMsg { get; }





  /// <summary>
  /// Модель ошибки валидации элемента.
  /// </summary>
  public class TCaseValidationFailure : ValidationFailure, ITCaseValidationFailure<T>
  {
    public TCaseValidationFailure(ITCase<T> tCase, string message)
    {
      TCase = tCase;
      ErrorMessage = message;
    }



    /// <summary>
    /// Ссылка на настройки правила валидации, которое вызвало ошибку.
    /// </summary>
    public ITCase<T> TCase { get; }
  }

}
