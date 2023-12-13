using NUnit.Framework;
using System.Collections.Generic;

namespace ricaun.DI.Tests
{
    public class Container_Tests
    {
        [Test]
        public void ContainerEmpty_ResolveIsNull()
        {
            var container = new Container();
            Assert.IsNull(container.ResolveOrNull<IContainer>());
            Assert.IsNull(container.ResolveOrNull<IContainerResolver>());
        }

        [Test]
        public void ContainerEmpty_NoSingleton()
        {
            var container = new Container();
            Assert.False(container.HasSingletonInstance<IContainer>());
        }

        [Test]
        public void ContainerEmpty_ResolveThrowsException()
        {
            var container = new Container();
            Assert.Throws<KeyNotFoundException>(() => { container.Resolve<IContainer>(); });
            Assert.Throws<KeyNotFoundException>(() => { container.Resolve<IContainerResolver>(); });
        }

        [Test]
        public void ContainerWithItself_ResolveIsNotNull()
        {
            var container = new Container();
            container.AddSingleton<IContainer>(container);
            container.AddSingleton<IContainerResolver>(container);
            Assert.IsNotNull(container.ResolveOrNull<IContainer>());
            Assert.IsNotNull(container.ResolveOrNull<IContainerResolver>());
        }

        [Test]
        public void ContainerUtils_ResolveIsNotNull()
        {
            var container = ContainerUtils.CreateContainer();
            Assert.IsNotNull(container.ResolveOrNull<IContainer>());
            Assert.IsNotNull(container.ResolveOrNull<IContainerResolver>());
        }

        [Test]
        public void ContainerUtils_InjectContainerToItself_IsNotNull()
        {
            var container = new Container();
            ContainerUtils.InjectContainerToItself(container);
            Assert.IsNotNull(container.ResolveOrNull<IContainer>());
            Assert.IsNotNull(container.ResolveOrNull<IContainerResolver>());
        }
    }
}