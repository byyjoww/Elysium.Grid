using System.Collections.Generic;

namespace Elysium.Tilemap
{
    public class TilemapCollection
    {
        public IEnumerable<UnityEngine.Tilemaps.Tilemap> tilemaps = default;

        public TilemapCollection(UnityEngine.Tilemaps.Tilemap _tilemap)
        {
            this.tilemaps = new UnityEngine.Tilemaps.Tilemap[] { _tilemap };
        }

        public TilemapCollection(IEnumerable<UnityEngine.Tilemaps.Tilemap> _tilemaps)
        {
            this.tilemaps = _tilemaps;
        }

        public IEnumerable<ITile> GetAllTilesOfType<T>()
        {
            IList<ITile> tiles = new List<ITile>();
            foreach (var tilemap in tilemaps)
            {
                foreach (var position in tilemap.cellBounds.allPositionsWithin)
                {
                    if (!tilemap.HasTile(position)) { continue; }
                    var cell = tilemap.GetTile(position);
                    if (typeof(T).IsAssignableFrom(cell.GetType()))
                    {
                        tiles.Add(new Tile(cell, tilemap, position));
                    }
                }
            }
            return tiles;
        }
    }
}
