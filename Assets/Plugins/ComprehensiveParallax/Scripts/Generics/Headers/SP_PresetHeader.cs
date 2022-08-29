namespace Arcturus.Parallax.Internal
{
    public class SP_PresetHeader : PresetHeaderBase
    {
        public override PresetBase GeneratePresetClass(ParallaxConfig config)
        {
            return new SP_ParallaxPreset(config);
        }

        public override string GetPresetName()
        {
            return "Sliding Pane";
        }
    }
}
