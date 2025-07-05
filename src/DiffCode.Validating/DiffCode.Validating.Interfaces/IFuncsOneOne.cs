using DiffCode.Validating.Interfaces.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiffCode.Validating.Interfaces;

/// <summary>
/// Интерфейс набора предикатов для проверки условий из категории "ЭЛЕМЕНТ VS. ЭЛЕМЕНТ"
/// (проверяемый элемент сопоставляется с другим элементом).
/// </summary>
public interface IFuncsOneOne
{


  /// ЭЛЕМЕНТ VS. ЭЛЕМЕНТ
  /// <summary>
  /// Один элемент равен другому.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="other"></param>
  /// <returns></returns>
  public Func<T, T, bool> OneEqualsOther<T>() => (one, other) => one.Equals(other);


  /// ЭЛЕМЕНТ VS. ЭЛЕМЕНТ
  /// <summary>
  /// Один элемент не равен другому.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="other"></param>
  /// <returns></returns>
  public Func<T, T, bool> OneNotEqualsOther<T>() => (one, other) => !one.Equals(other);


  /// ЭЛЕМЕНТ VS. ЭЛЕМЕНТ
  /// <summary>
  /// Один элемент больше другого.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public Func<T, T, bool> OneMoreThanOther<T>() where T : IComparable<T> => (one, other) => one.CompareTo(other) > 0;


  /// ЭЛЕМЕНТ VS. ЭЛЕМЕНТ
  /// <summary>
  /// Один элемент меньше другого.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public Func<T, T, bool> OneLessThanOther<T>() where T : IComparable<T> => (one, other) => one.CompareTo(other) < 0;


  /// ЭЛЕМЕНТ VS. ЭЛЕМЕНТ
  /// <summary>
  /// Элемент внутри диапазона.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="min"></param>
  /// <param name="max"></param>
  /// <returns></returns>
  public Func<T, T, bool> OneInRange<T>(T? min, T? max) where T : struct, INumber<T> => (one, _) => one >= (min ?? one) && one <= (max ?? one);


  /// ЭЛЕМЕНТ VS. ЭЛЕМЕНТ
  /// <summary>
  /// Элемент вне диапазона.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="min"></param>
  /// <param name="max"></param>
  /// <returns></returns>
  public Func<T, T, bool> OneNotInRange<T>(T? min, T? max) where T : struct, INumber<T> => (one, _) => !(one >= (min ?? one) && one <= (max ?? one));


  /// ЭЛЕМЕНТ VS. ЭЛЕМЕНТ
  /// <summary>
  /// Текстовое содержимое одного элемента соответствует паттерну.
  /// </summary>
  /// <returns></returns>
  public Func<string, string, bool> OneMatchesOther() => Regex.IsMatch;


  /// ЭЛЕМЕНТ VS. ЭЛЕМЕНТ
  /// <summary>
  /// Текстовое содержимое одного элемента не соответствует паттерну.
  /// </summary>
  /// <returns></returns>
  public Func<string, string, bool> OneNotMatchesOther() => (one, other) => !Regex.IsMatch(one, other);


  /// ЭЛЕМЕНТ VS. ЭЛЕМЕНТ
  /// <summary>
  /// Один тип равен другому типу (является другим типом/может быть сопоставлен с другим типом).
  /// </summary>
  /// <returns></returns>
  public Func<Type, Type, bool> OneIsOther() => (one, other) =>
  {
    bool ch1 = other.IsGenericTypeDefinition;
    bool ch2 = other.IsGenericTypeWithArguments();
    bool ch3 = other.IsConstructedGenericType;
    bool ch4 = one.BaseType.IsConstructedGenericType;
    var ddd = one.BaseType.GetGenericArguments();

    other = other.ReplaceGeneric(one);

    return other != null && (other == one || other.IsAssignableTo(one) || one.IsAssignableTo(other));
  };

}
