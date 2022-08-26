using Arcturus.Parallax.Internal;
using System.Collections.Generic;
using UnityEngine;

namespace Arcturus.Parallax
{
    public class ParallaxDriver : MonoBehaviour
    {
        public Camera parallaxCam;

        [SerializeField]
        private List<ParallaxConfig> parallaxConfigs = new List<ParallaxConfig>();

        private List<PresetBase> activeParallaxAssets;
        private Vector2 prevPos;

        private void Awake()
        {
            activeParallaxAssets = new List<PresetBase>();
            foreach (var config in parallaxConfigs)
            {
                switch (config.preset)
                {
                    case ParallaxPreset.InfiniteLoop:
                        activeParallaxAssets.Add(new IL_ParallaxPreset(config));
                        break;

                    case ParallaxPreset.SlidingPane:
                        activeParallaxAssets.Add(new SP_ParallaxPreset(config));
                        break;

                    case ParallaxPreset.DepthSlide:
                        activeParallaxAssets.Add(new DS_ParallaxPreset(config));
                        break;

                    default:
                        break;
                }
            }
        }

        private void Start()
        {
            UpdatePos();
        }

        private void UpdatePos()
        {
            prevPos = (Vector2)parallaxCam.transform.position;
        }

        private void LateUpdate()
        {
            foreach (var activeParallax in activeParallaxAssets)
                activeParallax.OperateParallax(parallaxCam, prevPos);

            UpdatePos();
        }
    }
}
