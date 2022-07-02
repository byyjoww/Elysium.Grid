using System.Collections.Generic;
using UnityEngine;

namespace Elysium.Tilemap
{
    public class TilemapProperties<T>
    {
        private Dictionary<Vector3, T> properties = default;
        private UnityEngine.Tilemaps.Tilemap tilemap = default;

        public TilemapProperties(Grid _grid)
        {
            var child = new GameObject($"Properties - {typeof(T).Name}");
            tilemap = child.AddComponent<UnityEngine.Tilemaps.Tilemap>();
            child.transform.SetParent(_grid.transform);
            properties = new Dictionary<Vector3, T>();
        }

        public bool Add(Vector3Int _position, T _property)
        {
            properties.Add(_position, _property);
            return true;
        }

        public bool TryGetPropertyAtPosition(Vector3Int _position, out T _property)
        {
            Vector3 center = tilemap.GetCellCenterWorld(_position);
            return properties.TryGetValue(center, out _property);
        }
    }
}
