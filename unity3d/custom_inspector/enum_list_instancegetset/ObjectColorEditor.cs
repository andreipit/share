using UnityEngine;
using UnityEditor;
using AvatarEditor;

public class ObjectColorEditor
{
    SerializedProperty m_baseTextureScale;
    SerializedProperty m_colors;
    SerializedProperty m_dict;
    SerializedProperty gType;
    //SerializedProperty TexturePriorityLevel;
    ObjectColor textureSettings;
    //SerializedProperty selfRef;

    #region Public methods

    public void GetDependencies(SerializedProperty reflection, ObjectColor obj)
    {
        //selfRef = reflection;
        m_baseTextureScale = reflection.FindPropertyRelative("m_baseTextureScale");
        m_colors = reflection.FindPropertyRelative("m_colors");
        m_dict = reflection.FindPropertyRelative("m_dict");
        gType = reflection.FindPropertyRelative("gType");

        //TexturePriorityLevel = obj.FindPropertyRelative("m_texturePriority");
        textureSettings = obj;
    }

    public void DrawInspector()
    {
        EditorUIElements.Separator();
        EditorGUILayout.LabelField("obj color editor version:");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Textures atlas scale:", GUILayout.MaxWidth(150));
        m_baseTextureScale.intValue = (int)EditorGUILayout.IntPopup(m_baseTextureScale.intValue,
                                                           new string[] { "1", "0.5", "0.25", "0.125", "0,015625" },
                                                           new int[] { 1, 2, 4, 8, 16 });
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Textures priority level:", GUILayout.MaxWidth(150));
        //TexturePriorityLevel.intValue = (int)EditorGUILayout.Slider(TexturePriorityLevel.intValue, 0, 5);
        textureSettings.TexturePriorityLevel = (int)EditorGUILayout.Slider(textureSettings.TexturePriorityLevel, 0, 5);

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.PropertyField(m_colors);
        for (int i = 0; i < m_colors.arraySize; i++)
        {
            EditorGUILayout.PropertyField(m_colors.GetArrayElementAtIndex(i));
        }

        //EditorGUILayout.PropertyField(m_dict);
        //for (int i = 0; i < m_dict.arraySize; i++)
        //{
        //    EditorGUILayout.PropertyField(m_dict.GetArrayElementAtIndex(i));
        //}

        foreach (var pair in m_dict)
        {
            EditorGUILayout.LabelField("pair:"+ pair.ToString(), GUILayout.MaxWidth(150));

        }

        EditorGUILayout.PropertyField(gType);

        EditorUIElements.Separator();

    }

    #endregion
}
