using UnityEngine;

namespace Arcturus.Parallax.Internal
{
    public abstract class PresetBase
    {
        protected ParallaxConfig config;

        public PresetBase(ParallaxConfig config)
        {
            this.config = config;
        }

        public abstract void OperateParallax(Camera cam, Vector2 previousCamPos, Transform subject);

        /// <summary>
        /// A helper function that shortens current position getting of a camera.
        /// </summary>
        /// <param name="cam"></param>
        /// <returns>Returns the current camera position as Vector2</returns>
        protected Vector2 GetCamPos(Camera cam)
        {
            return (Vector2)cam.transform.position;
        }
    }
}

