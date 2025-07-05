using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffCode.Validating.Interfaces.Extensions;


public static class TypeExtensions
{


  public static Type ReplaceGeneric(this Type type, Type from) =>
      type.IsGenericTypeDefinition && from.GetGenericArguments().Any()
      ?
      type.MakeGenericType(from.GetGenericArguments())
      :
      type.IsGenericTypeWithArguments() && from.IsConstructedGenericType
      ?
      type.GetGenericTypeDefinition().MakeGenericType(from.BaseType.GetGenericArguments())
      :
      from.BaseType.IsConstructedGenericType
      ?
      type.GetGenericTypeDefinition().MakeGenericType(from.BaseType.GetGenericArguments())
      :
      from.BaseType.IsConstructedGenericType
      ?
      type.MakeGenericType(from.BaseType.GetGenericArguments())
      :
      type;


  public static bool IsGenericTypeWithoutParams(this Type type) => type.IsGenericType && type.ContainsGenericParameters;


  public static bool IsGenericTypeWithArguments(this Type type) => type.IsGenericType && !type.ContainsGenericParameters && type.GenericTypeArguments.Length > 0;


  public static Type ComposeGenericType(this Type type, Type paramType) => type.MakeGenericType(paramType);

}
