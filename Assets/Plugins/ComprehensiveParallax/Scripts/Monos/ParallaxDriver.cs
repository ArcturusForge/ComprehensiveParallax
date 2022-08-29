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

        #region Helper Funcs
        private void UpdatePos()
        {
            prevPos = (Vector2)parallaxCam.transform.position;
        }
        #endregion

        private void Awake()
        {
            // Reflection nastiness
            var headerList = ParallaxAssemblyReflections.GetPresetHeaders();

            activeParallaxAssets = new List<PresetBase>();
            foreach (var config in parallaxConfigs)
            {
                //switch (config.preset)
                //{
                //    case ParallaxPreset.InfiniteLoop:
                //        activeParallaxAssets.Add(new IL_ParallaxPreset(config));
                //        break;

                //    case ParallaxPreset.SlidingPane:
                //        activeParallaxAssets.Add(new SP_ParallaxPreset(config));
                //        break;

                //    case ParallaxPreset.DepthSlide:
                //        activeParallaxAssets.Add(new DS_ParallaxPreset(config));
                //        break;

                //    default:
                //        break;
                //}

                // Find a matching PresetHeader.
                if (headerList.Exists(x => x.GetPresetName() == config.presetName))
                {
                    // Use the Presetheader to generate the ParallaxPreset for this config.
                    var header = headerList.Find(x => x.GetPresetName() == config.presetName);
                    activeParallaxAssets.Add(header.GeneratePresetClass(config));
                }
                else
                    Debug.LogError($"A parallax config is trying to use a preset that does not exist: {config.presetName}");
            }
        }

        private void Start()
        {
            UpdatePos();
        }

        private void LateUpdate()
        {
            foreach (var activeParallax in activeParallaxAssets)
                activeParallax.OperateParallax(parallaxCam, prevPos);

            UpdatePos();
        }
    }
}
