using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Elysium.Tilemap
{
    public class Tile : ITile
    {
        private UnityEngine.Tilemaps.TileBase baseTile = default;
        private UnityEngine.Tilemaps.Tilemap tilemap = default;
        private Vector3 center = default;

        public UnityEngine.Tilemaps.TileBase Base => baseTile;
        public UnityEngine.Tilemaps.Tilemap Tilemap => tilemap;
        public Vector3 Center => center;

        public Tile(UnityEngine.Tilemaps.TileBase _tile, UnityEngine.Tilemaps.Tilemap _tilemap, Vector3Int _position)
        {
            this.baseTile = _tile;
            this.tilemap = _tilemap;
            this.center = _tilemap.GetCellCenterWorld(_position);
        }
    }
}
