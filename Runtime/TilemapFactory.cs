using UnityEditor;
using UnityEngine;

namespace Elysium.Tilemap
{
    public static class TilemapFactory
    {
        [MenuItem("GameObject/2D Object/Elysium Tilemap")]
        public static void Create()
        {
            var go = new GameObject("Grid");
            go.AddComponent<UnityEngine.Grid>();            
            var child = new GameObject("Tilemap");
            child.AddComponent<UnityEngine.Tilemaps.Tilemap>();
            child.AddComponent<UnityEngine.Tilemaps.TilemapRenderer>();
            child.transform.SetParent(go.transform);
            go.AddComponent<Tilemapper>();
        }
    }
}
