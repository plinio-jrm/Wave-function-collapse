using System.Collections.Generic;
using UnityEngine;

namespace PlinioJRM.WFC {
    [CreateAssetMenu(fileName = "Tile", menuName = "Game/Generation/WFC/Tile")]
    public class WFCTile: ScriptableObject {
        public Transform prefab;
        [SerializeField]
        private bool _emptyTile;

        [Header("Direction Rules")]
        public List<WFCTile> up;
        public List<WFCTile> right;
        public List<WFCTile> down;
        public List<WFCTile> left;

        public bool IsEmptyTile() => _emptyTile;

        public int ID {
            get => prefab.ToString().GetHashCode();
        }
    }
}