using DiffCode.Validating.Abstractions;
using DiffCode.Validating.Interfaces;
using DiffCode.Validating.Interfaces.Extensions;
using System.Numerics;


namespace DiffCode.Validating.Models.Extensions;


public static class ValidatorExtensions
{



  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustBeEnlisted{T, V}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="V"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемое значение.</param>
  /// <param name="expr2">Список заданных значений.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustBeEnlisted<T, V>(this BaseElementValidator<T> validator, T elem, V expr1, IEnumerable<V> expr2) where T : IValidatable<T>
    => validator.FluentAction(() => validator.AddTCases(new MustBeEnlisted<T, V>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustBeEqual{T, V}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="V"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемое значение.</param>
  /// <param name="expr2">Целевое/заданное значение.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustBeEqual<T, V>(this BaseElementValidator<T> validator, T elem, V expr1, V expr2) where T : IValidatable<T>
    => validator.FluentAction(() => validator.AddTCases(new MustBeEqual<T, V>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustBeInRange{T, V}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="V"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемое значение.</param>
  /// <param name="expr2">Целевой/заданный интервал.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustBeInRange<T, V>(this BaseElementValidator<T> validator, T elem, V expr1, (V, V) expr2) where T : IValidatable<T> where V : struct, INumber<V>
    => validator.FluentAction(() => validator.AddTCases(new MustBeInRange<T, V>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustBeLessThan{T, V}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="V"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемое значение.</param>
  /// <param name="expr2">Целевое/заданное значение.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustBeLessThan<T, V>(this BaseElementValidator<T> validator, T elem, V expr1, V expr2) where T : IValidatable<T> where V : IComparable<V>
    => validator.FluentAction(() => validator.AddTCases(new MustBeLessThan<T, V>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustBeMoreThan{T, V}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="V"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемое значение.</param>
  /// <param name="expr2">Целевое/заданное значение.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustBeMoreThan<T, V>(this BaseElementValidator<T> validator, T elem, V expr1, V expr2) where T : IValidatable<T> where V : IComparable<V>
    => validator.FluentAction(() => validator.AddTCases(new MustBeMoreThan<T, V>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustBeNotEnlisted{T, V}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="V"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемое значение.</param>
  /// <param name="expr2">Список заданных значений.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustBeNotEnlisted<T, V>(this BaseElementValidator<T> validator, T elem, V expr1, IEnumerable<V> expr2) where T : IValidatable<T>
    => validator.FluentAction(() => validator.AddTCases(new MustBeNotEnlisted<T, V>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustBeNotEqual{T, V}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="V"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемое значение.</param>
  /// <param name="expr2">Целевое/заданное значение.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustBeNotEqual<T, V>(this BaseElementValidator<T> validator, T elem, V expr1, V expr2) where T : IValidatable<T>
    => validator.FluentAction(() => validator.AddTCases(new MustBeNotEqual<T, V>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustContainExactItems{T, V}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="V"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемый список значений.</param>
  /// <param name="expr2">Целевой/заданный список.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustContainExactItems<T, V>(this BaseElementValidator<T> validator, T elem, IEnumerable<V> expr1, IEnumerable<V> expr2) where T : IValidatable<T>
    => validator.FluentAction(() => validator.AddTCases(new MustContainExactItems<T, V>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustContainFirstItem{T, V}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="V"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемый список значений.</param>
  /// <param name="expr2">Целевое/заданное значение.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustContainFirstItem<T, V>(this BaseElementValidator<T> validator, T elem, IEnumerable<V> expr1, V expr2) where T : IValidatable<T>
    => validator.FluentAction(() => validator.AddTCases(new MustContainFirstItem<T, V>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustContainLastItem{T, V}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="V"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемый список значений.</param>
  /// <param name="expr2">Целевое/заданное значение.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustContainLastItem<T, V>(this BaseElementValidator<T> validator, T elem, IEnumerable<V> expr1, V expr2) where T : IValidatable<T>
    => validator.FluentAction(() => validator.AddTCases(new MustContainLastItem<T, V>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustCountItems{T, V}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <typeparam name="V"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемый список значений.</param>
  /// <param name="expr2">Целевое/заданное значение.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustCountItems<T, V>(this BaseElementValidator<T> validator, T elem, IEnumerable<V> expr1, int expr2) where T : IValidatable<T>
    => validator.FluentAction(() => validator.AddTCases(new MustCountItems<T, V>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustMatchText{T}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемое значение.</param>
  /// <param name="expr2">Целевое/заданное значение.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustMatchText<T>(this BaseElementValidator<T> validator, T elem, string expr1, string expr2) where T : IValidatable<T>
    => validator.FluentAction(() => validator.AddTCases(new MustMatchText<T>(() => elem, p => expr1, () => expr2)));


  /// <summary>
  /// Добавляет к валидатору новое правило валидации типа <see cref="Models.MustNotMatchText{T}"/>.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="validator">Валидатор.</param>
  /// <param name="elem">Валидируемый объект.</param>
  /// <param name="expr1">Валидируемое значение.</param>
  /// <param name="expr2">Целевое/заданное значение.</param>
  /// <returns></returns>
  public static BaseElementValidator<T> MustNotMatchText<T>(this BaseElementValidator<T> validator, T elem, string expr1, string expr2) where T : IValidatable<T>
    => validator.FluentAction(() => validator.AddTCases(new MustNotMatchText<T>(() => elem, p => expr1, () => expr2)));




}