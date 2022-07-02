using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Elysium.Tilemap.Editor
{
    [CustomEditor(typeof(UnityEngine.Tilemaps.Tilemap))]
    public class TilemapEditor : UnityEditor.Editor
    {
        private UnityEngine.Tilemaps.Tilemap tilemap = default;
        private TilemapCollider2D tilemapCollider = default;
        private CompositeCollider2D compositeCollider = default;
        private Rigidbody2D rigidbody2d = default;
        private bool isCollisionEnabled = default;
        private bool isCollisionComposite = default;

        private void OnEnable()
        {
            tilemap = target as UnityEngine.Tilemaps.Tilemap;
            tilemapCollider = tilemap.GetComponent<TilemapCollider2D>();
            compositeCollider = tilemap.GetComponent<CompositeCollider2D>();
            rigidbody2d = tilemap.GetComponent<Rigidbody2D>();
            isCollisionEnabled = tilemapCollider != null;
            isCollisionComposite = compositeCollider != null;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            base.OnInspectorGUI();
            EditorGUILayout.BeginHorizontal();
            HandleCollisionMethods();
            EditorGUILayout.EndHorizontal();
            serializedObject.ApplyModifiedProperties();
        }

        private void HandleCollisionMethods()
        {
            if (isCollisionEnabled)
            {
                if (isCollisionComposite)
                {
                    if (GUILayout.Button("Disable Composite"))
                    {
                        DisableComposite();
                    }
                }
                else
                {
                    if (GUILayout.Button("Enable Composite"))
                    {
                        EnableComposite();
                    }
                }

                if (GUILayout.Button("Disable Collisions")) 
                {
                    DisableComposite();
                    DisableCollisions();
                }
            }
            else
            {
                if (GUILayout.Button("Enable Collisions")) 
                {
                    EnableCollisions();
                    DisableComposite();
                }
            }
        }

        private void DisableCollisions()
        {
            isCollisionEnabled = false;
            DestroyImmediate(tilemapCollider);            
            
        }

        private void EnableCollisions()
        {
            isCollisionEnabled = true;
            tilemapCollider = tilemap.gameObject.AddComponent<TilemapCollider2D>();            
        }

        private void DisableComposite()
        {
            if (compositeCollider != null) { DestroyImmediate(compositeCollider); }
            if (rigidbody2d != null) { DestroyImmediate(rigidbody2d); }
            tilemapCollider.usedByComposite = false;
        }

        private void EnableComposite()
        {
            rigidbody2d = tilemap.gameObject.AddComponent<Rigidbody2D>();
            compositeCollider = tilemap.gameObject.AddComponent<CompositeCollider2D>();            
            rigidbody2d.bodyType = RigidbodyType2D.Static;
            tilemapCollider.usedByComposite = true;
        }
    }
}
