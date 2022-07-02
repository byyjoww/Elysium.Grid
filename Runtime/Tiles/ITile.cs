using UnityEngine;

namespace Elysium.Tilemap
{
    public interface ITile
    {
        UnityEngine.Tilemaps.TileBase Base { get; }
        UnityEngine.Tilemaps.Tilemap Tilemap { get; }
        Vector3 Center { get; }
    }
}
