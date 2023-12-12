﻿using System;

namespace ricaun.DI
{
    /// <summary>
    /// DI container contract
    /// </summary>
    public interface IContainer : IContainerResolver, IContainerConsolePrint, IContainerScopedInstances
    {
        /// <summary>
        /// Adds an implementation as a singleton on the container.
        /// </summary>
        void AddSingleton(Type implementationType);

        /// <summary>
        /// Adds an implementation as a singleton on the container.
        /// </summary>
        void AddSingleton<TImplementation>() where TImplementation : class;

        /// <summary>
        /// Adds an instance as a singleton on the container
        /// </summary>
        void AddSingleton<TImplementation>(TImplementation instance) where TImplementation : class;

        /// <summary>
        /// Adds an implementation to a contract as a singleton on the container
        /// </summary>
        void AddSingleton(Type contractType, Type implementationType);

        /// <summary>
        /// Adds an implementation to a contract as a singleton on the container
        /// </summary>
        void AddSingleton<TContract, TImplementation>() where TImplementation : class, TContract;

        /// <summary>
        /// Adds an instance as a singleton on the container
        /// </summary>
        void AddSingleton<TContract, TImplementation>(TImplementation instance) where TImplementation : TContract;

        /// <summary>
        /// Adds a scoped implementation to a contract on the container.
        /// </summary>
        void AddScoped(Type contractType, Type implementationType);

        /// <summary>
        /// Adds a scoped implementation to a contract on the container.
        /// </summary>
        void AddScoped<TContract, TImplementation>() where TImplementation : class, TContract;

        /// <summary>
        /// Adds a scoped implementation on the container.
        /// </summary>
        void AddScoped(Type implementationType);

        /// <summary>
        /// Adds a scoped implementation on the container.
        /// </summary>
        void AddScoped<TImplementation>() where TImplementation : class;

        /// <summary>
        /// Adds an implementation as transient on the container
        /// </summary>
        void AddTransient(Type implementationType);

        /// <summary>
        /// Adds an implementation as a transient on the container.
        /// </summary>
        void AddTransient<TImplementation>() where TImplementation : class;

        /// <summary>
        /// Adds an implementation to a contract as transient on the container
        /// </summary>
        void AddTransient(Type contractType, Type implementationType);

        /// <summary>
        /// Adds an implementation to a contract as transient on the container
        /// </summary>
        void AddTransient<TContract, TImplementation>() where TImplementation : class, TContract;

        /// <summary>
        /// Resets the entire container
        /// </summary>
        void Clear();
    }
}
