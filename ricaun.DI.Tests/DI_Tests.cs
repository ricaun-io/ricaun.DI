using NUnit.Framework;
using ricaun.DI.Tests.Utils;

namespace ricaun.DI.Tests
{
    public class DI_Tests : BaseContainerTests
    {
        [Test]
        public void DI_A_ResolveIsNotNull()
        {
            Container.AddScoped<IA, A>();
            Assert.IsNotNull(Container.ResolveOrNull<IA>());
        }

        [Test]
        public void DI_A_ContainerDispose()
        {
            Container.AddScoped<IA, A>();
            var a = Container.ResolveOrNull<IA>();
            Container.Dispose();
            Assert.False(a.IsDispose);
        }

        [Test]
        public void DI_A_ContainerDispose_Enable()
        {
            Container.AddScoped<IA, A>();
            Container.EnableDisposeScopedInstances(true);
            var a = Container.ResolveOrNull<IA>();
            Container.Dispose();
            Assert.True(a.IsDispose);
        }

        [Test]
        public void ContainerUtils_ContainerDispose()
        {
            var container = ContainerUtils.CreateContainer();
            container.AddScoped<IA, A>();
            var a = container.ResolveOrNull<IA>();
            container.Dispose();
            Assert.False(a.IsDispose);
        }

        [Test]
        public void ContainerUtils_ContainerDispose_Disable()
        {
            var container = ContainerUtils.CreateContainer(false);
            container.AddScoped<IA, A>();
            var a = container.ResolveOrNull<IA>();
            container.Dispose();
            Assert.False(a.IsDispose);
        }

        [Test]
        public void ContainerUtils_ContainerDispose_Enable()
        {
            var container = ContainerUtils.CreateContainer(true);
            container.AddScoped<IA, A>();
            var a = container.ResolveOrNull<IA>();
            container.Dispose();
            Assert.True(a.IsDispose);
        }

        [Test]
        public void DI_B_ResolveIsNotNull()
        {
            Container.AddScoped<IA, A>();
            Container.AddScoped<IB, B>();
            Assert.IsNotNull(Container.ResolveOrNull<IB>());
        }

        [Test]
        public void DI_B_WithOutA_ResolveIsNull()
        {
            Container.AddScoped<IB, B>();
            Assert.IsNull(Container.ResolveOrNull<IB>());
        }

        [Test]
        public void DI_C_ResolveIsNotNull()
        {
            Container.AddScoped<IA, A>();
            Container.AddScoped<IB, B>();
            Container.AddScoped<IC, C>();
            Assert.IsNotNull(Container.ResolveOrNull<IC>());
        }

        [Test]
        public void DI_C_WithOutA_ResolveIsNull()
        {
            Container.AddScoped<IB, B>();
            Container.AddScoped<IC, C>();
            Assert.IsNull(Container.ResolveOrNull<IC>());
        }

        [Test]
        public void DI_C_WithOutB_ResolveIsNull()
        {
            Container.AddScoped<IA, A>();
            Container.AddScoped<IC, C>();
            Assert.IsNull(Container.ResolveOrNull<IC>());
        }

        [Test]
        public void DI_D_ResolveIsNotNull()
        {
            Container.AddScoped<IA, A>();
            Container.AddScoped<IB, B>();
            Container.AddScoped<IC, C>();
            Container.AddScoped<ID, D>();
            Assert.IsNotNull(Container.ResolveOrNull<ID>());
        }
    }
}