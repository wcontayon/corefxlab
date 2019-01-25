﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Reflection;

namespace System.Text.Json.Serialization
{
    internal class JsonReflectionMaterializer : JsonMemberBasedClassMaterializer
    {
        public override JsonClassInfo.ConstructorDelegate CreateConstructor(Type type)
        {
            return () => Activator.CreateInstance(type);
        }

        public override JsonPropertyInfo<TValue>.GetterDelegate CreateGetter<TValue>(PropertyInfo propertyInfo)
        {
            return (obj) =>
            {
                MethodInfo getter = propertyInfo.GetGetMethod(nonPublic: true);
                return (TValue)getter.Invoke(obj, Array.Empty<object>());
            };
        }

        public override JsonPropertyInfo<TValue>.SetterDelegate CreateSetter<TValue>(PropertyInfo propertyInfo)
        {
            return (obj, propertyValue) =>
            {
                MethodInfo setter = propertyInfo.GetSetMethod(nonPublic: true);
                setter.Invoke(obj, new object[] { propertyValue });
            };
        }
    }
}
