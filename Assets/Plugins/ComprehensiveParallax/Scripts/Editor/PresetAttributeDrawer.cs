using System;
using UnityEditor;
using UnityEngine;

namespace Arcturus.Parallax.Internal
{
    [CustomPropertyDrawer(typeof(PresetEntryAttribute))]
    public class PresetAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var presetAttribute = attribute as PresetEntryAttribute;
            var nameList = presetAttribute.PresetNamesList;
            if (property.propertyType == SerializedPropertyType.String)
            {
                int index = Mathf.Max(0, Array.IndexOf(nameList, property.stringValue));
                index = EditorGUI.Popup(position, property.displayName, index, nameList);

                property.stringValue = nameList[index];
            }
            else if (property.propertyType == SerializedPropertyType.Integer)
            {
                property.intValue = EditorGUI.Popup(position, property.displayName, property.intValue, nameList);
            }
            else
            {
                base.OnGUI(position, property, label);
            }
        }
    }
}
