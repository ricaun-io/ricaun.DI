namespace ricaun.DI
{
    /// <summary>
    /// DI container utils
    /// </summary>
    public static class ContainerUtils
    {
        /// <summary>
        /// Create container with itself registered as a singleton.
        /// </summary>
        /// <returns>The created container.</returns>
        public static IContainer CreateContainer()
        {
            var container = new Container();
            return InjectContainerToItself(container);
        }

        /// <summary>
        /// Inject container to itself as a singleton.
        /// </summary>
        /// <param name="container"></param>
        /// <returns>The container itself.</returns>
        public static IContainer InjectContainerToItself(IContainer container)
        {
            container.AddSingleton(container);
            container.AddSingleton<IContainerResolver>(container);
            return container;
        }
    }
}
