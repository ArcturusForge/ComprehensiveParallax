using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// https://forum.unity.com/threads/finding-all-scripts-of-a-certain-type-not-monobehavior.918866/
/// https://stackoverflow.com/questions/752/how-to-create-a-new-object-instance-from-a-type
/// </summary>

namespace Arcturus.Parallax.Internal
{
    public static class ParallaxAssemblyReflections
    {
        public static List<PresetHeaderBase> GetPresetHeaders()
        {
            var headerList = new List<PresetHeaderBase>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Compile a list of all existing Script Types that inherit from PresetHeaderBase.
                var typeList = assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(PresetHeaderBase))).ToList();

                // Interate through the list of Types.
                foreach (var type in typeList)
                {
                    // Create a temporary instance of these PresetHeader scripts.
                    var instance = (PresetHeaderBase)Activator.CreateInstance(type);

                    // Store temp instance in list.
                    headerList.Add(instance);
                }
            }
            return headerList;
        }
    }
}
