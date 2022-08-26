using UnityEngine;

namespace Arcturus.Parallax
{
    [System.Serializable]
    public class ParallaxConfig
    {
        [Header("Setup Based Data")]
        public ParallaxPreset preset;
        public ParallaxDirection direction;
        public GameObject parallaxAsset;

        [Header("Preset Based Data")]
        // Only used in some presets
        [Tooltip("\"Depth Slide\" preset does not use this variable!")]
        public Vector2 slideSpeed;
    }
}
