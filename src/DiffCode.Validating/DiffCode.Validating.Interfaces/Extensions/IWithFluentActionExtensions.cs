namespace DiffCode.Validating.Interfaces.Extensions;

/// <summary>
/// Методы расширения для интерфейса <see cref="IWithFluentAction"/>.
/// </summary>
public static class IWithFluentActionExtensions
{




  public static TInvoker FluentForEachAction<TInvoker, TItem>(this TInvoker invoker, IEnumerable<TItem> items, Action<TItem> action) where TInvoker : IWithFluentAction
  {
    foreach (var item in items)
    {
      action(item);
    }
    return invoker;
  }



  public static TInvoker FluentAction<TInvoker>(this TInvoker invoker, Action action) where TInvoker : IWithFluentAction
  {
    action();
    return invoker;
  }



  public static TInvoker FluentAction<TInvoker, TParam1>(this TInvoker invoker, TParam1 param1, Action<TParam1> action) where TInvoker : IWithFluentAction
  {
    action(param1);
    return invoker;
  }



  public static TInvoker FluentAction<TInvoker, TParam1, TParam2>(this TInvoker invoker, TParam1 param1, TParam2 param2, Action<TParam1, TParam2> action) where TInvoker : IWithFluentAction
  {
    action(param1, param2);
    return invoker;
  }




  public static TInvoker FluentAction<TInvoker, TParam1, TParam2, TParam3>(this TInvoker invoker, TParam1 param1, TParam2 param2, TParam3 param3, Action<TParam1, TParam2, TParam3> action) where TInvoker : IWithFluentAction
  {
    action(param1, param2, param3);
    return invoker;
  }

}
