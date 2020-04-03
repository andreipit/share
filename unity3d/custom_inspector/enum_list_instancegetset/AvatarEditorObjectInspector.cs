using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AvatarEditor;

[CustomEditor(typeof(AvatarEditorObject))]
public class AvatarEditorObjectInspector : Editor
{
    AvatarEditorObject m_editorObject;
    bool m_selected;
    //SerializedProperty m_textureSettings;
    //SerializedProperty m_objectColor;
    TextureSettingsEditor texSetEditor;
    ObjectColorEditor objColEditor;
    ObjectColorsEditor objColsEditor;


    #region Public methods

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (OnSelect())
            m_editorObject.CutVolumes.FindAllFreeFormBoxes();

        m_editorObject.DrawInspector();
        texSetEditor.DrawInspector();

        EditorGUILayout.Space();
        EditorUIElements.Separator();
        EditorGUILayout.Space();

        objColEditor.DrawInspector();

        EditorGUILayout.Space();
        EditorUIElements.Separator();
        EditorGUILayout.Space();

        objColsEditor.DrawInspector();

        EditorGUILayout.Space();
        EditorUIElements.Separator();
        EditorGUILayout.Space();

        serializedObject.ApplyModifiedProperties();
    }

    #endregion


    #region Private methods

    private void OnEnable()
    {
        m_editorObject = target as AvatarEditor.AvatarEditorObject;
        texSetEditor = new TextureSettingsEditor();
        objColEditor = new ObjectColorEditor();
        objColsEditor = new ObjectColorsEditor();

        //m_textureSettings = serializedObject.FindProperty("m_textureSettings");
        //m_objectColor = serializedObject.FindProperty("m_objectColor");

        texSetEditor.GetDependencies(GetObject("m_textureSettings"), m_editorObject.TextureSet);
        objColEditor.GetDependencies(GetObject("m_objectColor"), m_editorObject.ObjColor);
        objColsEditor.GetDependencies(GetObject("m_objectColors"), m_editorObject.ObjColors);
    }

    SerializedProperty GetObject(string name)
    {
        return serializedObject.FindProperty(name);
    }

    private bool OnSelect()
    {
        if (Selection.activeGameObject == m_editorObject.gameObject)
        {
            if(!m_selected)
            {
                m_selected = true;

                return true;
            }
        }
        else
            m_selected = false;

        return false;
    }

    #endregion
}
