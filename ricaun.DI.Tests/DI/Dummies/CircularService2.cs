namespace ricaun.DI.Tests.DI.Dummies
{
    public class CircularService2
    {
        public CircularService2(DummyService dummyService, CircularService3 circularService3)
        {
        }
    }
}
