using NUnit.Framework;
using ricaun.DI.Tests.Utils;

namespace ricaun.DI.Tests
{
    public class Transient_Tests : BaseContainerTests
    {
        [Test]
        public void Transient_ResolveIsNotNull()
        {
            Assert.IsNull(Container.ResolveOrNull<ITransient>());
            Container.AddTransient<ITransient, Transient>();
            Assert.IsNotNull(Container.ResolveOrNull<ITransient>());
        }

        [Test]
        public void Transient_NoContract_ResolveIsNotNull()
        {
            Container.AddTransient<Transient>();
            Assert.IsNotNull(Container.ResolveOrNull<Transient>());
        }

        [Test]
        public void Transient_NotAddTransient_ResolveIsNotNull()
        {
            Assert.IsNotNull(Container.ResolveOrNull<Transient>());
        }

        [Test]
        public void Transient_ResolveAreNotEquals()
        {
            Container.AddTransient<ITransient, Transient>();
            var transient = Container.ResolveOrNull<ITransient>();
            Assert.AreNotEqual(transient, Container.ResolveOrNull<ITransient>());
        }
    }
}