namespace ricaun.DI.Tests.DI.Dummies
{
    public class CircularService3
    {
        public CircularService3(CircularService2 circularService2)
        {
        }
    }
}
