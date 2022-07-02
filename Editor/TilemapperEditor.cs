using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Elysium.Tilemap.Editor
{
    [CustomEditor(typeof(Tilemapper))]
    public class TilemapperEditor : UnityEditor.Editor
    {
        protected Tilemapper adaptor = default;

        protected virtual GUIStyle WindowStyle
        {
            get
            {
                GUIStyle style = GUI.skin.window;
                style.padding.top = 5;
                style.padding.bottom = 5;
                style.padding.left = 10;
                return style;
            }
        }

        protected void OnEnable()
        {
            adaptor = (Tilemapper)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawDefaultInspector();
            DrawItems();
            DrawButtons();
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawButtons()
        {
            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Add Tilemap")) { adaptor.AddTilemap(); }
            if (GUILayout.Button("Refresh")) { adaptor.OnValidate(); }
            EditorGUILayout.EndHorizontal();
        }

        protected virtual void DrawItems()
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Tilemaps", EditorStyles.largeLabel);
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical(WindowStyle);
            int numOfItems = adaptor.Tilemaps.Count();
            for (int i = 0; i < numOfItems; i++)
            {
                EditorGUILayout.BeginHorizontal();

                TilemapDataWrapper wrapper = adaptor.Tilemaps.ElementAt(i);

                string name = wrapper.Name;
                GUILayout.Label("Tilemap:", GUILayout.Width(55));
                GUILayout.TextField(name);
                GUILayout.Space(10);
                int order = wrapper.OrderInLayer;
                GUILayout.Label("Order:", GUILayout.Width(40));
                GUILayout.TextField(order.ToString());

                EditorGUILayout.EndHorizontal();
            }

            if (numOfItems == 0)
            {
                GUILayout.Label("Empty");
            }

            EditorGUILayout.EndVertical();
        }
    }
}
