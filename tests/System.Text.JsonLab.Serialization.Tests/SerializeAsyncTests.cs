﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace System.Text.Json.Serialization.Tests
{
    public partial class SerializeTests
    {
        [Fact]
        public static async Task SerializeSimpleObjectAsync()
        {
            MemoryStream stream = new MemoryStream(SimpleTestClass.s_data);
            JsonConverterSettings settings = new JsonConverterSettings
            {
                DefaultBufferSize = 1
            };

            SimpleTestClass obj = await stream.FromJsonAsync<SimpleTestClass>(settings);
            obj.Verify();
        }

        [Fact]
        public static async Task SerializePrimitivesAsync()
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(@"1"));
            JsonConverterSettings settings = new JsonConverterSettings
            {
                DefaultBufferSize = 1
            };

            System.Diagnostics.Debugger.Break();

            int i = await stream.FromJsonAsync<int>(settings);
            Assert.Equal(1, i);
        }
    }
}
