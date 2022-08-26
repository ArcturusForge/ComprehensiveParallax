using Arcturus.Parallax.Internal;
using UnityEngine;

namespace Arcturus.Parallax
{
    public class IL_ParallaxPreset : PresetBase
    {
        public IL_ParallaxPreset(ParallaxConfig config) : base(config)
        {

        }

        public override void OperateParallax(Camera cam, Vector2 previousCamPos)
        {
            throw new System.NotImplementedException();
        }
    }
}
