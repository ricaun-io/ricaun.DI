using NUnit.Framework;
using ricaun.DI.Tests.Utils;
using System;

namespace ricaun.DI.Tests
{
    public class Scoped_Tests : BaseContainerTests
    {
        [Test]
        public void Scoped_ResolveIsNotNull()
        {
            Assert.IsNull(Container.ResolveOrNull<IScoped>());
            Container.AddScoped<IScoped, Scoped>();
            Assert.IsNotNull(Container.ResolveOrNull<IScoped>());
        }

        [Test]
        public void Scoped_AddAbstract_Throws()
        {
            Assert.Throws<InvalidOperationException>(Container.AddScoped<Abstract>);
        }

        [Test]
        public void Scoped_AddInterface_Throws()
        {
            Assert.Throws<InvalidOperationException>(Container.AddScoped<IScoped>);
        }

        [Test]
        public void Scoped_HasScoped()
        {
            Container.AddScoped<IScoped, Scoped>();
            Assert.True(Container.HasScopedInstance<IScoped>());
        }

        [Test]
        public void Scoped_NoContract_ResolveIsNotNull()
        {
            Container.AddScoped<Scoped>();
            Assert.IsNotNull(Container.ResolveOrNull<Scoped>());
        }

        [Test]
        public void Scoped_ResolveAreEquals()
        {
            Container.AddScoped<IScoped, Scoped>();
            var scoped = Container.ResolveOrNull<IScoped>();
            Assert.AreEqual(scoped, Container.ResolveOrNull<IScoped>());
        }

        [Test]
        public void Scoped_CreateScope_ResolveAreNotEquals()
        {
            Container.AddScoped<IScoped, Scoped>();
            var scoped = Container.ResolveOrNull<IScoped>();

            var container = Container.CreateScope();
            var scopedTwo = container.ResolveOrNull<IScoped>();

            Assert.AreNotEqual(scoped, scopedTwo);
        }
    }
}