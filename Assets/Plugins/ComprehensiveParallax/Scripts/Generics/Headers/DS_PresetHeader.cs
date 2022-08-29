using Arcturus.Parallax;
using Arcturus.Parallax.Internal;

public class DS_PresetHeader : PresetHeaderBase
{
    // Please ensure your preset inherits from the "PresetBase" class before trying to use it.
    public override PresetBase GeneratePresetClass(ParallaxConfig config)
    {
        return new DS_ParallaxPreset(config);
    }

    // Returns the preset name that is displayed as a selectable option in the inspector.
    public override string GetPresetName()
    {
        return "Depth Slide";
    }
}
