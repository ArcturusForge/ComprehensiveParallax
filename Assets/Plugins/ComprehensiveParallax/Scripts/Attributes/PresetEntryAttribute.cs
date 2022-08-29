using UnityEngine;

/// <summary>
/// https://gist.github.com/ProGM/9cb9ae1f7c8c2a4bd3873e4df14a6687
/// </summary>

namespace Arcturus.Parallax.Internal
{
    public class PresetEntryAttribute : PropertyAttribute
    {
        public string[] PresetNamesList { get; private set; }

        public PresetEntryAttribute()
        {
            PresetNamesList = typeof(PresetAttributeHelper).GetMethod("AllPresetNames").Invoke(null, null) as string[];
        }
    }
}
