using Arcturus.Parallax.Internal;
using UnityEngine;

namespace Arcturus.Parallax
{
    [System.Serializable]
    public class ParallaxConfig
    {
        [Header("Setup Data")]
        [PresetEntry] public string presetName;
        public ParallaxDirection direction;
        public GameObject parallaxAsset;

        [Header("Preset Data")]
        // Only used in some presets
        [Tooltip("\"Depth Slide\" preset does not use this variable!\nSpeed 1 = Stuck on camera.\nSpeed 0 = Stuck on position.")]
        public Vector2 slideSpeed;
    }
}
