using System;
using System.Collections.Generic;
using System.Linq;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, List<object>> services = new Dictionary<Type, List<object>>();

    public static void RegisterService<T>(T service) where T : class
    {
        var type = service.GetType(); // Use the concrete type of the service
        if (!services.ContainsKey(type))
        {
            services[type] = new List<object>();
        }
        services[type].Add(service);
    }

    public static IEnumerable<T> GetServices<T>() where T : class
    {
        services.TryGetValue(typeof(T), out var serviceList);
        return serviceList?.Cast<T>() ?? Enumerable.Empty<T>();
    }

    public static T GetService<T>(int index = 0) where T : class
    {
        services.TryGetValue(typeof(T), out var serviceList);
        return serviceList != null && serviceList.Count > index ? serviceList[index] as T : null;
    }
}
