using System;
using System.Linq;
using System.Reflection;

namespace AttributesAndReflection
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }

        //bool Load(MyApplication application);
    }

    public class UsingReflection
    {
        public static void GetPluginByAssemblyName(string filePath)
        {
            // Inspecting an assembly for types that implement a custom interface
            AssemblyName assemblyName = AssemblyName.GetAssemblyName(filePath);
            Assembly pluginAssembly = Assembly.Load(assemblyName);            
            
            Console.WriteLine(assemblyName);

            var plugins = from type in pluginAssembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;

            foreach (Type pluginType in plugins)
            {                
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
                Console.WriteLine(plugin.Name);
                Console.WriteLine(plugin.Description);

                DumpObjectVariables(plugin);
                DumpObjectMethods(plugin);
            }
        }

        private static void DumpObjectVariables(object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(int))
                {
                    Console.WriteLine("Integer: " + field.GetValue(obj));
                }
                else if (field.FieldType == typeof(string))
                {
                    Console.WriteLine("string: " + field.GetValue(obj));
                }
            }            
        }

        private static void DumpObjectMethods(object obj)
        {
            MethodInfo[] methods = obj.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (MethodInfo method in methods)
            {
                method.Invoke(obj, null);                
            }            
        }       
    }
} 