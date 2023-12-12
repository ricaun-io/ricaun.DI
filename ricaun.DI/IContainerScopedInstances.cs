namespace ricaun.DI
{
    /// <summary>
    /// Contract Type for disposing scoped instances on Container
    /// </summary>
    public interface IContainerScopedInstances
    {
        /// <summary>
        /// Enables or disables the disposal of all scoped instances when the container <see cref="System.IDisposable.Dispose"/>. Default is true.
        /// </summary>
        /// <param name="enabled">flag to enable or disable dispose scoped instances.</param>
        public void EnableDisposeScopedInstances(bool enabled);
    }
}
