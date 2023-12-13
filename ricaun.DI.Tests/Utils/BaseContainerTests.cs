using NUnit.Framework;
using System;

namespace ricaun.DI.Tests.Utils
{
    public abstract class BaseContainerTests
    {
        public abstract class Abstract { }
        public class Singleton : ISingleton { }
        public interface ISingleton { }
        public class Scoped : IScoped { }
        public interface IScoped { }
        public class Transient : ITransient { }
        public interface ITransient { }

        protected IContainer Container { get; private set; }
        [SetUp]
        public void Setup()
        {
            Container = ContainerUtils.CreateContainer();
        }
        [TearDown]
        public void TearDown()
        {
            Container?.Dispose();
        }

        #region DI
        public interface IA
        {
            public bool IsDispose { get; }
        }
        public class A : IA, IDisposable
        {
            public A() { }

            public void Dispose()
            {
                this.IsDispose = true;
            }
            public bool IsDispose { get; private set; }
        }
        public interface IB
        {
            public IA A { get; }
        }
        public class B : IB
        {
            public B(IA a)
            {
                A = a;
            }

            public IA A { get; }
        }
        public interface IC
        {
            public IA A { get; }
            public IB B { get; }
        }
        public class C : IC
        {
            public C(IA a, IB b)
            {
                A = a;
                B = b;
            }

            public IA A { get; }
            public IB B { get; }
        }
        public interface ID
        {
            public IA A { get; }
            public IB B { get; }
            public IC C { get; }
        }
        public class D : ID
        {
            public D(IA a, IB b, IC c)
            {
                A = a;
                B = b;
                C = c;
            }
            public IA A { get; }
            public IB B { get; }
            public IC C { get; }
        }
        #endregion
    }
}