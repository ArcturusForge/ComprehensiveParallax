namespace Arcturus.Parallax.Internal
{
    public abstract class PresetHeaderBase
    {
        public abstract string GetPresetName();
        public abstract PresetBase GeneratePresetClass(ParallaxConfig config);
    }
}
