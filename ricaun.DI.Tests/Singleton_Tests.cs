using NUnit.Framework;
using ricaun.DI.Tests.Utils;
using System;

namespace ricaun.DI.Tests
{
    public class Singleton_Tests : BaseContainerTests
    {
        [Test]
        public void Singleton_ResolveIsNotNull()
        {
            Assert.IsNull(Container.ResolveOrNull<ISingleton>());
            Container.AddSingleton<ISingleton, Singleton>();
            Assert.IsNotNull(Container.ResolveOrNull<ISingleton>());
        }

        [Test]
        public void Singleton_AddAbstract_Throws()
        {
            Assert.Throws<InvalidOperationException>(Container.AddSingleton<Abstract>);
        }

        [Test]
        public void Singleton_AddInterface_Throws()
        {
            Assert.Throws<InvalidOperationException>(Container.AddSingleton<ISingleton>);
        }

        [Test]
        public void Singleton_HasSingleton()
        {
            Container.AddSingleton<ISingleton, Singleton>();
            Assert.True(Container.HasSingletonInstance<ISingleton>());
        }

        [Test]
        public void Singleton_NoContract_ResolveIsNotNull()
        {
            Container.AddSingleton<Singleton>();
            Assert.IsNotNull(Container.ResolveOrNull<Singleton>());
        }

        [Test]
        public void Singleton_Instance_ResolveIsNotNull()
        {
            var singleton = new Singleton();
            Container.AddSingleton<ISingleton>(singleton);
            Assert.IsNotNull(Container.ResolveOrNull<ISingleton>());
        }

        [Test]
        public void Singleton_Instance_AreEqual()
        {
            var singleton = new Singleton();
            Container.AddSingleton<ISingleton>(singleton);
            Assert.AreEqual(singleton, Container.ResolveOrNull<ISingleton>());
        }

        [Test]
        public void Singleton_Instance_NoContract_AreEqual()
        {
            var singleton = new Singleton();
            Container.AddSingleton(singleton);
            Assert.AreEqual(singleton, Container.ResolveOrNull<Singleton>());
        }
    }
}