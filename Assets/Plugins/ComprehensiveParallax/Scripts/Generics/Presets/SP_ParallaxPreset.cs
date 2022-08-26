using Arcturus.Parallax.Internal;
using UnityEngine;

namespace Arcturus.Parallax
{
    public class SP_ParallaxPreset : PresetBase
    {
        public SP_ParallaxPreset(ParallaxConfig config) : base(config)
        {

        }

        public override void OperateParallax(Camera cam, Vector2 previousCamPos)
        {
            throw new System.NotImplementedException();
        }
    }
}
