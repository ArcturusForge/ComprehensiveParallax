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
            var movement = (Vector2)cam.transform.position - previousCamPos;

            if (movement == Vector2.zero) return;

            var pAsset = config.parallaxAsset.transform;
            Vector3 targetPos;

            switch (config.direction)
            {
                case ParallaxDirection.Vertical:
                    targetPos = new Vector3(pAsset.position.x, pAsset.position.y + movement.y * config.slideSpeed.y, pAsset.position.z);
                    break;

                case ParallaxDirection.Horizontal:
                    targetPos = new Vector3(pAsset.position.x + movement.x * config.slideSpeed.x, pAsset.position.y, pAsset.position.z);
                    break;

                case ParallaxDirection.Both:
                    targetPos = new Vector3(pAsset.position.x + movement.x * config.slideSpeed.x, pAsset.position.y + movement.y * config.slideSpeed.y, pAsset.position.z);
                    break;

                default:
                    targetPos = Vector3.zero;
                    break;
            }

            pAsset.position = targetPos;
        }
    }
}
