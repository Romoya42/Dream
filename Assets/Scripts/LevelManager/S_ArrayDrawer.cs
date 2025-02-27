using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GameObject[][]))]
public class GameObjectArrayDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        
        // Affiche un tableau 2D dans l'inspecteur
        SerializedProperty arrayProperty = property.FindPropertyRelative("levels");

        for (int i = 0; i < arrayProperty.arraySize; i++)
        {
            EditorGUI.PropertyField(new Rect(position.x, position.y + i * 20, position.width, position.height), arrayProperty.GetArrayElementAtIndex(i), new GUIContent("Level " + (i + 1)));
        }

        EditorGUI.EndProperty();
    }
}
