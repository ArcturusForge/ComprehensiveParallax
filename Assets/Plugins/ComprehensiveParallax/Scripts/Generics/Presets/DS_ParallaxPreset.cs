using Arcturus.Parallax.Internal;
using UnityEngine;

/// <summary>
/// Source:
/// https://www.youtube.com/watch?v=tMXgLBwtsvI
/// </summary>

namespace Arcturus.Parallax
{
    public class DS_ParallaxPreset : PresetBase
    {
        private Vector2 startPosition;
        private float startZ;

        public DS_ParallaxPreset(ParallaxConfig config) : base(config)
        {
            startPosition = config.parallaxAsset.transform.position;
            startZ = config.parallaxAsset.transform.position.z;
        }

        public override void OperateParallax(Camera cam, Vector2 previousCamPos, Transform subject)
        {
            var travel = GetCamPos(cam) - startPosition;
            var distanceFromSubject = config.parallaxAsset.transform.position.z - subject.position.z;
            var clippingPlane = (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));
            var parallaxFactor = Mathf.Abs(distanceFromSubject) / clippingPlane;

            var newPos = startPosition + travel * parallaxFactor;

            switch (config.direction)
            {
                case ParallaxDirection.Vertical:
                    config.parallaxAsset.transform.position = new Vector3(startPosition.x, newPos.y, startZ);
                    break;

                case ParallaxDirection.Horizontal:
                    config.parallaxAsset.transform.position = new Vector3(newPos.x, startPosition.y, startZ);
                    break;

                case ParallaxDirection.Both:
                    config.parallaxAsset.transform.position = new Vector3(newPos.x, newPos.y, startZ);
                    break;

                default:
                    break;
            }
        }
    }
}
