using NUnit.Framework;
using ricaun.DI.Tests.Utils;

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
        public void Scoped_HasSingleton()
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