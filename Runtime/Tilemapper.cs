using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Elysium.Tilemap
{
    public class Tilemapper : MonoBehaviour
    {
        [SerializeField] private Grid Grid = default;
        [SerializeField, HideInInspector] private TilemapDataWrapper[] tilemaps = default;

        public IEnumerable<TilemapDataWrapper> Tilemaps => tilemaps;        

        #region EDITOR

        [ContextMenu("Add")]
        public void AddTilemap()
        {
            var child = new GameObject("Tilemap");
            child.AddComponent<UnityEngine.Tilemaps.Tilemap>();
            child.AddComponent<UnityEngine.Tilemaps.TilemapRenderer>();
            child.transform.SetParent(transform);
            OnValidate();
        }

        [ContextMenu("Refresh")]
        public void OnValidate()
        {
            if (Grid == null) { Grid = GetComponent<Grid>(); }
            Sort();
            var maps = GetComponentsInChildren<UnityEngine.Tilemaps.Tilemap>();
            tilemaps = maps.Select(x => new TilemapDataWrapper(x)).ToArray();            
        }
        
        private void Sort()
        {
            List<UnityEngine.Tilemaps.TilemapRenderer> children = new List<UnityEngine.Tilemaps.TilemapRenderer>();
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i).GetComponent<UnityEngine.Tilemaps.TilemapRenderer>();
                children.Add(child);
                child.transform.SetParent(null);
            }

            children.Sort((UnityEngine.Tilemaps.TilemapRenderer t1, UnityEngine.Tilemaps.TilemapRenderer t2) => {
                return t1.sortingOrder.CompareTo(t2.sortingOrder);
            });

            foreach (var child in children)
            {
                child.transform.SetParent(transform);
            }
        }
        #endregion
    }
}
