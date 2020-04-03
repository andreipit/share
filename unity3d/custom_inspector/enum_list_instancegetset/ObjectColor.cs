using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AvatarEditor
{
    [System.Serializable]
    public class ObjectColor
    {
        [System.Serializable]
        public class ColorGroup
        {
            public string LinkRootName;
            public Transform LocalRoot;

            public ColorGroup()
            {
                LinkRootName = "Root";
            }
        }

        [HideInInspector] [SerializeField] [Range(0, 5)] private int m_texturePriority = 5;
        [HideInInspector] [SerializeField] private int m_baseTextureScale = 1;

        [SerializeField]
        private List<Color32> m_colors = new List<Color32>(){
            new Color32(100,0,0,0),
            new Color32(0,100,0,0),
        };

        [SerializeField]  public Dictionary<int, string> m_dict = new Dictionary<int, string>() { { 111, "a" },{ 222, "b" },{ 333, "c" } };


        //[SerializeField] List<string> m_colors = new List<string>()
        //{
        //    "carrot",
        //    "fox",
        //    "explorer"
        //};

        enum GenderTypes { Male, Female, Common };
        [SerializeField] GenderTypes gType = GenderTypes.Common;

        #region Properties

        public int TexturePriorityLevel { get { return m_texturePriority; } set { m_texturePriority = value; } }
        public float BaseTextureScale { get { return 1f / (float)m_baseTextureScale; } }

        #endregion


        #region Public methods

        public void DrawInspector()
        {
            EditorGUILayout.LabelField("START native obj color--------");
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Textures atlas scale:", GUILayout.MaxWidth(150));
            m_baseTextureScale = (int)EditorGUILayout.IntPopup(m_baseTextureScale, new string[] { "1", "0.5", "0.25", "0.125", "0,015625" }, new int[] { 1, 2, 4, 8, 16 });
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Textures priority level:", GUILayout.MaxWidth(150));
            TexturePriorityLevel = (int)EditorGUILayout.Slider(TexturePriorityLevel, 0, 5);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.LabelField("END native obj color--------");
        }

        #endregion


        #region Private methods

        #endregion
    }
}
