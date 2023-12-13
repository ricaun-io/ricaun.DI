# ricaun.DI

[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](https://github.com/ricaun-io/ricaun.DI)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](https://github.com/ricaun-io/ricaun.DI/actions/workflows/Build.yml/badge.svg)](https://github.com/ricaun-io/ricaun.DI/actions)
[![Release](https://img.shields.io/nuget/v/ricaun.DI?logo=nuget&label=release&color=blue)](https://www.nuget.org/packages/ricaun.DI)

[![ricaun.DI](https://raw.githubusercontent.com/ricaun-io/ricaun.DI/develop/assets/ricaun.DI.png)](https://github.com/ricaun-io/ricaun.DI)
[![ricaun.DI](https://github.com/ricaun-io/ricaun.DI/blob/develop/assets/ricaun.DI.png?raw=true)](https://github.com/ricaun-io/ricaun.DI)
[![Banner](https://github.com/ricaun/test-assets/blob/main/Banner.png?raw=true)](https://github.com/ricaun-io/ricaun.DI)
[![Banner](https://raw.githubusercontent.com/ricaun/test-assets/main/Banner.png)](https://github.com/ricaun-io/ricaun.DI)

Create a `Container` and register your dependencies with `AddSingleton`, `AddScoped` and `AddTransient` methods. 
Resolve your dependencies with `Resolve` method.

## ricaun.Revit.DI

To use this library in Autodesk Revit, use the [ricaun.Revit.DI](https://github.com/ricaun-io/ricaun.Revit.DI) library.

## Implementation Reference

This project uses the same implementation from [Onboxframework](https://github.com/engthiago/Onboxframework) IOC container system, except by:

***The `Container` when `Dispose` can dispose all `IDisposable` scoped instances registered in the container.***

## Container

```C#
// Empty Container.
Container container = new Container();
```

```C#
// Dispose Container.
container.Dispose();
```

### ContainerUtils

```C#
// Create Container with itself registered as a singleton.
IContainer container = ContainerUtils.CreateContainer();
```

```C#
// Create Container with itself registered as a singleton, with dispose scoped instances enabled.
IContainer container = ContainerUtils.CreateContainer(true);
```

### Singleton
```C#
// Register a singleton.
var singleton = new Singleton();
container.AddSingleton(singleton);
container.AddSingleton<ISingleton>(singleton);
container.AddSingleton<ISingleton, Singleton>();
container.AddSingleton<ISingleton, Singleton>(singleton);
```

### Scoped
```C#
// Register a scoped.
container.AddScoped<Scoped>();
container.AddScoped<IScoped, Scoped>();
```

### Transient
```C#
// Register a transient.
container.AddTransient<Transient>();
container.AddTransient<ITransient, Transient>();
```

### Resolve
```C#
// Resolve the ISingleton.
var singleton = container.Resolve<ISingleton>();
```

```C#
// Resolve the IScoped.
var scoped = container.Resolve<IScoped>();
```

```C#
// Resolve the ITransient.
var transient = container.Resolve<ITransient>();
```

### ResolveOrNull
```C#
// Resolve the ISingleton.
var singleton = container.ResolveOrNull<ISingleton>();
```

```C#
// Resolve the IScoped.
var scoped = container.ResolveOrNull<IScoped>();
```

```C#
// Resolve the ITransient.
var transient = container.ResolveOrNull<ITransient>();
```

### Enable Console
```C#
// Enable Console.
container.EnableConsolePrinting(true);
```

### Enable Dispose Scoped Instances
```C#
// Enable Dispose Scoped Instances.
container.EnableDisposeScopedInstances(true);
```

## Static Container Example

Simple `Host` static class to hold the container.

```C#
using ricaun.DI;
public static class Host
{
    public static IContainer Container { get; } = ContainerUtils.CreateContainer();
    public static IContainerResolver ContainerResolver => Container;
    public static T Resolve<T>() where T : class => ContainerResolver.Resolve<T>();
    public static T ResolveOrNull<T>() where T : class => ContainerResolver.ResolveOrNull<T>();
}
```

Extension for the `IHost` interface.

```C#
public interface IHost { }
public static class HostExtension
{
    public static IContainer GetContainer(this IHost _) => Host.Container;
    public static IContainerResolver GetContainerResolver(this IHost _) => Host.ContainerResolver;
    public static T Resolve<T>(this IHost _) where T : class => Host.Resolve<T>();
    public static T ResolveOrNull<T>(this IHost _) where T : class => Host.ResolveOrNull<T>();
}
```

## Release

* [Latest release](https://github.com/ricaun-io/ricaun.DI/releases/latest)

## License

This project is [licensed](LICENSE) under the [MIT Licence](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](https://github.com/ricaun-io/ricaun.DI/stargazers)!