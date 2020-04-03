using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AvatarEditor
{
    public class AvatarEditorObject : MonoBehaviour
    {
        [HideInInspector] [SerializeField] private ObjectInfo m_info;
        [HideInInspector] [SerializeField] private AdditionalRig m_additionalRig;
        [HideInInspector] [SerializeField] private CutVolumesObject m_cutVolumes;
        [HideInInspector] [SerializeField] private List<FreeFormBox> m_freeFormBoxesCutVolumes;
        [HideInInspector] [SerializeField] private TextureSettings m_textureSettings;
        [HideInInspector] [SerializeField] private ObjectColor m_objectColor;
        [HideInInspector] [SerializeField] private ObjectColors m_objectColors;

        //[HideInInspector] [SerializeField] [Range(0, 5)] private int m_texturePriority = 5;
        //[HideInInspector] [SerializeField] private int m_baseTextureScale = 1;


        #region Properties

        public ObjectInfo Info
        {
            get
            {
                if (m_info == null)
                    m_info = new ObjectInfo();
                return m_info;

            }
        }

        public AdditionalRig ExtraRig
        {
            get
            {
                if (m_additionalRig == null)
                    m_additionalRig = new AdditionalRig();
                return m_additionalRig;
            }
        }

        public CutVolumesObject CutVolumes
        {
            get
            {
                if (m_cutVolumes == null)
                    m_cutVolumes = new CutVolumesObject(transform);
                return m_cutVolumes;
            }
        }

        public TextureSettings TextureSet
        {
            get
            {
                if (m_textureSettings == null)
                    m_textureSettings = new TextureSettings();
                return m_textureSettings;
            }
        }

        public ObjectColor ObjColor
        {
            get
            {
                if (m_objectColor == null)
                    m_objectColor = new ObjectColor();
                return m_objectColor;
            }
        }

        public ObjectColors ObjColors
        {
            get
            {
                if (m_objectColors == null)
                    m_objectColors = new ObjectColors();
                return m_objectColors;
            }
        }

        //public int TexturePriorityLevel { get { return m_texturePriority; } private set { m_texturePriority = value; } }

        //public float BaseTextureScale { get { return 1f / (float)m_baseTextureScale; } }

        #endregion


        #region Public methods

        public void DrawInspector()
        {
            EditorGUI.BeginChangeCheck();

            Info.DrawInspector();

            EditorGUILayout.Space();
            EditorUIElements.Separator();
            EditorGUILayout.Space();

            ExtraRig.DrawInspector();

            EditorGUILayout.Space();
            EditorUIElements.Separator();
            EditorGUILayout.Space();

            CutVolumes.DrawInspector(transform);

            EditorGUILayout.Space();
            EditorUIElements.Separator();
            EditorGUILayout.Space();

            //DrawTexturesInspector();
            TextureSet.DrawInspector();

            EditorGUILayout.Space();
            EditorUIElements.Separator();
            EditorGUILayout.Space();

            ObjColors.DrawInspector();

            EditorGUILayout.Space();
            EditorUIElements.Separator();
            EditorGUILayout.Space();

            EditorGUILayout.Space();

            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(this);
        }

        #endregion


        #region Private methods

        //Inspector

        //private void DrawTexturesInspector()
        //{
        //    EditorGUILayout.BeginHorizontal();
        //    EditorGUILayout.LabelField("Textures atlas scale:", GUILayout.MaxWidth(150));
        //    m_baseTextureScale = (int)EditorGUILayout.IntPopup(m_baseTextureScale,
        //                                                       new string[] { "1", "0.5", "0.25", "0.125", "0,015625" },
        //                                                       new int[] { 1, 2, 4, 8, 16 });
        //    EditorGUILayout.EndHorizontal();

        //    EditorGUILayout.BeginHorizontal();
        //    EditorGUILayout.LabelField("Textures priority level:", GUILayout.MaxWidth(150));
        //    TexturePriorityLevel = (int)EditorGUILayout.Slider(TexturePriorityLevel, 0, 5);
        //    EditorGUILayout.EndHorizontal();
        //}

        #endregion
    }
}
