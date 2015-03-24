using System;
using System.Collections.Generic;
using Realm.Library.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Realm.Server.Test.Realm.Server.Handlers
{
    [TestClass]
    public class PropertyContextTest
    {
        enum EnumTest { Test }

        [TestMethod]
        public void PropertyContext_SetProperty_StringKey_Test()
        {
            var target = new PropertyContext(null);
            
            target.SetProperty("Test", new object());

            const bool expected = true;
            var actual = target.HasProperty("Test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_SetProperty_Exists_NotVolatile_Test()
        {
            const int firstValue = 5;
            const int secondValue = 10;
            var target = new PropertyContext(null);

            target.SetProperty("Test", firstValue);
            Assert.AreEqual(firstValue, target.GetProperty<int>("Test"));

            target.SetProperty("Test", secondValue);
            Assert.AreEqual(firstValue, target.GetProperty<int>("Test"));
        }

        [TestMethod]
        public void PropertyContext_SetProperty_Exists_Volatile_Test()
        {
            const int firstValue = 5;
            const int secondValue = 10;
            var target = new PropertyContext(null);

            target.SetProperty("Test", firstValue, PropertyTypeOptions.Volatile);
            Assert.AreEqual(firstValue, target.GetProperty<int>("Test"));

            target.SetProperty("Test", secondValue);
            Assert.AreEqual(secondValue, target.GetProperty<int>("Test"));
        }

        [TestMethod]
        public void PropertyContext_SetProperty_EnumKey_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty(EnumTest.Test, new object(), PropertyTypeOptions.None);

            const bool expected = true;
            var actual = target.HasProperty("Test");
            Assert.AreEqual(expected, actual); 
        }

        [TestMethod]
        public void PropertyContext_HasProperty_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", new object());

            const bool expected = true;
            var actual = target.HasProperty("Test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_GetProperty_Test()
        {
            var target = new PropertyContext(null);

            var expected = new object();
            target.SetProperty("Test", expected);

            var actual = target.GetProperty<object>("Test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_GetBooleanProperty_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", true);

            const bool expected = true;
            var actual = target.GetProperty<bool>("Test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_GetStringProperty_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", "Testing");

            const string expected = "Testing";
            var actual = target.GetProperty<string>("Test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_GetIntProperty_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", 512);

            const int expected = 512;
            var actual = target.GetProperty<int>("Test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_GetLongProperty_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", 10000000000000);

            const long expected = 10000000000000;
            var actual = target.GetProperty<long>("Test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
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
            Assert.AreEqual(expected, keyList.Count);
        }

        [TestMethod]
        public void PropertyContext_GetPropertyCount_Test()
        {
            var target = new PropertyContext(null);

            target.SetProperty("Test", 1);
            target.SetProperty("Tester", 2);

            const int expected = 2;
            var actual = target.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_IsPersistable_NotFound_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1, PropertyTypeOptions.Persistable);

            const bool expected = false;
            var actual = target.IsPersistable("Tester");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_IsPersistable_Found_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1, PropertyTypeOptions.Persistable);

            const bool expected = true;
            var actual = target.IsPersistable("Test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_IsVolatile_NotFound_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1);

            const bool expected = false;
            var actual = target.IsVolatile("Tester");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_IsVolatile_Found_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1, PropertyTypeOptions.Volatile);

            const bool expected = true;
            var actual = target.IsVolatile("Test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_IsVisible_NotFound_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1);

            const bool expected = false;
            var actual = target.IsVisible("Tester");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_IsVisible_Found_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1, PropertyTypeOptions.Visible);

            const bool expected = true;
            var actual = target.IsVisible("Test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_RemoveProperty_NotFound_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1);

            const bool expected = false;
            var actual = target.RemoveProperty("Tester");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_RemoveProperty_Found_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1);

            const bool expected = true;
            var actual = target.RemoveProperty("Test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PropertyContext_GetPropertyBits_NotFound_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1);

            var actual = target.GetPropertyBits("Tester");
            Assert.AreEqual(actual, string.Empty);
        }

        [TestMethod]
        public void PropertyContext_GetPropertyBits_Found_Test()
        {
            var target = new PropertyContext(null);
            target.SetProperty("Test", 1, PropertyTypeOptions.Persistable | PropertyTypeOptions.Visible | PropertyTypeOptions.Volatile);

            const string expected = "pvi";
            var actual = target.GetPropertyBits("Test");
            Assert.AreEqual(expected, actual);
        }
    }
}
