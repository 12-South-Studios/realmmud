using System;
using System.Collections.Generic;
using Realm.Library.Common;
using Realm.Library.Common.Contexts;
using Xunit;
using FluentAssertions;

namespace Realm.Server.Test.Realm.Server.Handlers
{
    public class PropertyContextTest
    {
        enum EnumTest { Test }

        [Fact]
        public void PropertyContext_SetProperty_StringKey_Test()
        {
            var target = new PropertyContext(null);
            
            target.SetProperty("Test", new object());

            const bool expected = true;
            var actual = target.HasProperty("Test");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_SetProperty_Exists_NotVolatile_Test()
        {
            const int firstValue = 5;
            const int secondValue = 10;
            var target = new PropertyContext(null);

            target.SetProperty("Test", firstValue);
            target.GetProperty<int>("Test").Should().Be(firstValue);

            target.SetProperty("Test", secondValue);
            target.GetProperty<int>("Test").Should().Be(firstValue);
        }

        [Fact]
        public void PropertyContext_SetProperty_Exists_Volatile_Test()
        {
            const int firstValue = 5;
            const int secondValue = 10;
            var target = new PropertyContext(null);

            target.SetProperty("Test", firstValue, PropertyTypeOptions.Volatile);
            target.GetProperty<int>("Test").Should().Be(firstValue);

            target.SetProperty("Test", secondValue);
            target.GetProperty<int>("Test").Should().Be(secondValue);
        }

        [Fact]
        public void PropertyContext_SetProperty_EnumKey_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty(EnumTest.Test, new object());

            const bool expected = true;
            var actual = target.HasProperty("Test");
            actual.Should().Be(expected); 
        }

        [Fact]
        public void PropertyContext_HasProperty_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", new object());

            const bool expected = true;
            var actual = target.HasProperty("Test");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_GetProperty_Test()
        {
            var target = new PropertyContext(null);

            var expected = new object();
            target.SetProperty("Test", expected);

            var actual = target.GetProperty<object>("Test");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_GetBooleanProperty_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", true);

            const bool expected = true;
            var actual = target.GetProperty<bool>("Test");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_GetStringProperty_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", "Testing");

            const string expected = "Testing";
            var actual = target.GetProperty<string>("Test");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_GetIntProperty_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", 512);

            const int expected = 512;
            var actual = target.GetProperty<int>("Test");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_GetLongProperty_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", 10000000000000);

            const long expected = 10000000000000;
            var actual = target.GetProperty<long>("Test");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_GetPropertyKeys_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", 1);
            target.SetProperty("Tester", 2);

            const int expected = 2;
            var actual = target.PropertyKeys;
            if (actual == null)
                throw new Exception("Object list is null");
            var keyList = new List<string>(actual);
            keyList.Count.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_GetPropertyCount_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", 1);
            target.SetProperty("Tester", 2);

            const int expected = 2;
            var actual = target.Count;
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_IsPersistable_NotFound_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1, PropertyTypeOptions.Persistable);

            const bool expected = false;
            var actual = target.IsPersistable("Tester");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_IsPersistable_Found_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1, PropertyTypeOptions.Persistable);

            const bool expected = true;
            var actual = target.IsPersistable("Test");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_IsVolatile_NotFound_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1);

            const bool expected = false;
            var actual = target.IsVolatile("Tester");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_IsVolatile_Found_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1, PropertyTypeOptions.Volatile);

            const bool expected = true;
            var actual = target.IsVolatile("Test");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_IsVisible_NotFound_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1);

            const bool expected = false;
            var actual = target.IsVisible("Tester");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_IsVisible_Found_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1, PropertyTypeOptions.Visible);

            const bool expected = true;
            var actual = target.IsVisible("Test");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_RemoveProperty_NotFound_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1);

            const bool expected = false;
            var actual = target.RemoveProperty("Tester");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_RemoveProperty_Found_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1);

            const bool expected = true;
            var actual = target.RemoveProperty("Test");
            actual.Should().Be(expected);
        }

        [Fact]
        public void PropertyContext_GetPropertyBits_NotFound_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1);

            var actual = target.GetPropertyBits("Tester");
            actual.Should().BeEmpty();
        }

        [Fact]
        public void PropertyContext_GetPropertyBits_Found_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1, PropertyTypeOptions.Persistable | PropertyTypeOptions.Visible | PropertyTypeOptions.Volatile);

            const string expected = "pvi";
            var actual = target.GetPropertyBits("Test");
            actual.Should().Be(expected);
        }
    }
}
