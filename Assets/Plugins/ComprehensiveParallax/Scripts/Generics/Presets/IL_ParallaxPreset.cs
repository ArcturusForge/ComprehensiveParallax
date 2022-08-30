using Arcturus.Parallax.Internal;
using UnityEngine;

/// <summary>
/// Source:
/// https://www.youtube.com/watch?v=wBol2xzxCOU
/// 
/// Important:
/// Parallax asset's positions (local & global) must be at (0,0) or they will blast off to infinity and beyond.
/// </summary>

namespace Arcturus.Parallax
{
    public class IL_ParallaxPreset : PresetBase
    {
        private float textureUnitSizeX;
        private float textureUnitSizeY;

        public IL_ParallaxPreset(ParallaxConfig config) : base(config)
        {
            var sprite = config.parallaxAsset.GetComponent<SpriteRenderer>().sprite;
            var texture = sprite.texture;
            textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
            textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
        }

        public override void OperateParallax(Camera cam, Vector2 previousCamPos, Transform subject)
        {
            var deltaMovement = GetCamPos(cam) - previousCamPos;

            switch (config.direction)
            {
                case ParallaxDirection.Vertical:
                    config.parallaxAsset.transform.position += new Vector3(config.parallaxAsset.transform.position.x, deltaMovement.y * config.slideSpeed.y, config.parallaxAsset.transform.position.z);
                    InfiniteY(cam);
                    break;

                case ParallaxDirection.Horizontal:
                    config.parallaxAsset.transform.position += new Vector3(deltaMovement.x * config.slideSpeed.x, config.parallaxAsset.transform.position.y, config.parallaxAsset.transform.position.z);
                    InfiniteX(cam);
                    break;

                case ParallaxDirection.Both:
                    config.parallaxAsset.transform.position += new Vector3(deltaMovement.x * config.slideSpeed.x, deltaMovement.y * config.slideSpeed.y, config.parallaxAsset.transform.position.z);
                    InfiniteX(cam);
                    InfiniteY(cam);
                    break;

                default:
                    break;
            }
        }

        private void InfiniteX(Camera cam)
        {
            var camPos = GetCamPos(cam);
            if (Mathf.Abs(camPos.x - config.parallaxAsset.transform.position.x) >= textureUnitSizeX)
            {
                var offsetPositionX = (camPos.x - config.parallaxAsset.transform.position.x) % textureUnitSizeX;
                config.parallaxAsset.transform.position = new Vector3(camPos.x + offsetPositionX, config.parallaxAsset.transform.position.y);
            }
        }

        private void InfiniteY(Camera cam)
        {
            var camPos = GetCamPos(cam);
            if (Mathf.Abs(camPos.y - config.parallaxAsset.transform.position.y) >= textureUnitSizeY)
            {
                var offsetPositionY = (camPos.y - config.parallaxAsset.transform.position.y) % textureUnitSizeY;
                config.parallaxAsset.transform.position = new Vector3(config.parallaxAsset.transform.position.x, camPos.y + offsetPositionY);
            }
        }
    }
}
