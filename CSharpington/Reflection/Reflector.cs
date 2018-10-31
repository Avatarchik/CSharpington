using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lasm.Reflection
{
    public static class Reflector
    {
        /// <summary>
        /// Finds all types derived from another type, including abstracts.
        /// </summary>
        public static List<Type> GetAllOfType(Type derivedType)
        {
            List<System.Type> result = new List<System.Type>();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            for (int assembly = 0; assembly < assemblies.Length; assembly++)
            {
                Type[] types = assemblies[assembly].GetTypes();

                for (int type = 0; type < types.Length; type++)
                {
                    if (derivedType.IsAssignableFrom(types[type]))
                    {
                        result.Add(types[type]);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Finds and returns all types derived from another type. Excludes abstracts.
        /// </summary>
        public static List<Type> GetTypesOfType(Type derivedType)
        {
            List<System.Type> result = new List<System.Type>();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            
            for (int assembly = 0; assembly < assemblies.Length; assembly++)
            {
                Type[] types = assemblies[assembly].GetTypes();

                for (int type = 0; type < types.Length; type++)
                {
                    if (!types[type].IsAbstract && derivedType.IsAssignableFrom(types[type]))
                    {
                        result.Add(types[type]);
                    }
                }
            }

            return result;
        }
    }
}
