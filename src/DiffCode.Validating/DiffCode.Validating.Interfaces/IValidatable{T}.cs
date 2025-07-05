namespace DiffCode.Validating.Interfaces;

/// <summary>
/// Интерфейс объекта, поддерживающего валидацию своего состояния.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IValidatable<out T> where T : IValidatable<T>
{

}
