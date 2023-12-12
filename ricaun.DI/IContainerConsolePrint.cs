﻿namespace ricaun.DI
{
    /// <summary>
    /// Contract Type for printing Container events to the console
    /// </summary>
    public interface IContainerConsolePrint
    {
        /// <summary>
        /// Enables console writeline for important events on the container. E.g: When the container is instantiating an object.
        /// </summary>
        /// <param name="enabled">flag to enable or disable console priting.</param>
        void EnableConsolePrinting(bool enabled);
    }
}
