using System.Collections.Generic;

namespace Arcturus.Parallax.Internal
{
    public static class PresetAttributeHelper
    {
        public static string[] AllPresetNames()
        {
            var temp = ParallaxAssemblyReflections.GetPresetHeaders();
            var retList = new List<string>();
            foreach (var preset in temp)
                retList.Add(preset.GetPresetName());
            return retList.ToArray();
        }
    }
}
