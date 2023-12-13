# ricaun.DI

[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](https://github.com/ricaun-io/ricaun.DI)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](https://github.com/ricaun-io/ricaun.DI/actions/workflows/Build.yml/badge.svg)](https://github.com/ricaun-io/ricaun.DI/actions)
[![.NET Framework 4.5](https://img.shields.io/badge/.NET%20Framework%204.5-blue.svg)](https://github.com/ricaun-io/ricaun.DI)
[![.NET Standard 2.0](https://img.shields.io/badge/-.NET%20Standard%202.0-blue)](https://github.com/ricaun-io/ricaun.DI)
[![.NET 5.0](https://img.shields.io/badge/-.NET%205.0-blue)](https://github.com/ricaun-io/ricaun.DI)

[![ricaun.DI](https://github.com/ricaun-io/.github/assets/12437519/6e3c013c-71f2-46d8-b73a-1fd0d72d8f63)](https://github.com/ricaun-io/ricaun.DI)
Create a `Container` and register your dependencies with `AddSingleton`, `AddScoped` and `AddTransient` methods. 
Resolve your dependencies with `Resolve` method.

## Implementation Reference

This project uses the same implementation from [Onboxframework](https://github.com/engthiago/Onboxframework) IOC container system, except by:
***The `Container` when `Dispose` will dispose all `IDisposable` scoped instances registered in the container.***

## Container

```C#
// Create Container with itself registered as a singleton.
IContainer container = ContainerUtils.CreateContainer();
```

```C#
// Empty Container.
Container container = new Container();
```

```C#
// Dispose Container.
container.Dispose();
```

## Singleton
```C#
// Register a singleton.
var singleton = new Singleton();
container.AddSingleton(singleton);
container.AddSingleton<ISingleton>(singleton);
container.AddSingleton<ISingleton, Singleton>();
container.AddSingleton<ISingleton, Singleton>(singleton);
```

## Scoped
```C#
// Register a scoped.
container.AddScoped<Scoped>();
container.AddScoped<IScoped, Scoped>();
```

## Transient
```C#
// Register a transient.
container.AddTransient<Transient>();
container.AddTransient<ITransient, Transient>();
```

## Resolve
```C#
var singleton = container.Resolve<ISingleton>();
```

```C#
var scoped = container.Resolve<IScoped>();
```

```C#
var transient = container.Resolve<ITransient>();
```

### ResolveOrNull
```C#
var singleton = container.ResolveOrNull<ISingleton>();
```

```C#
var scoped = container.ResolveOrNull<IScoped>();
```

```C#
var transient = container.ResolveOrNull<ITransient>();
```

## Enable Console
```C#
// Enable Console.
container.EnableConsolePrinting(true);
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