using Elysium.Core.Attributes;
using UnityEngine;

namespace Elysium.Tilemap
{
    [System.Serializable]
    public class TilemapDataWrapper
    {
        [SerializeField, ReadOnly] private string name = default;
        [SerializeField, ReadOnly] private int orderInLayer = default;
        [SerializeField, HideInInspector] private UnityEngine.Tilemaps.Tilemap tilemap = default;
        [SerializeField, HideInInspector] private UnityEngine.Tilemaps.TilemapRenderer renderer = default;

        public string Name => name;
        public int OrderInLayer => orderInLayer;
        public UnityEngine.Tilemaps.Tilemap Tilemap => tilemap;
        public UnityEngine.Tilemaps.TilemapRenderer Renderer => renderer;        

        public TilemapDataWrapper(UnityEngine.Tilemaps.Tilemap _tilemap)
        {
            this.name = _tilemap.name;
            this.tilemap = _tilemap;
            this.renderer = _tilemap.GetComponent<UnityEngine.Tilemaps.TilemapRenderer>();
            this.orderInLayer = this.renderer.sortingOrder;
        }
    }
}
