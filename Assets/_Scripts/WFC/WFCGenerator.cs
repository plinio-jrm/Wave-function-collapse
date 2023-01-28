using PlinioJRM.Helpers;
using PlinioJRM.World;

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace PlinioJRM.WFC {
    public class WFCGenerator : MonoBehaviour {
        [SerializeField]
        private List<WFCTile> _tiles;
        [SerializeField]
        private int _worldSize;
        private List<Tile> _generatedTiles;

        private void Start() => Generate();

        private void OnDrawGizmos() {
            if (_generatedTiles == null || !_generatedTiles.Any())
                return;

            foreach (ITile tile in _generatedTiles) {
                Vector2Int posInt = tile.GetPosition();
                Vector3 pos = new Vector3(posInt.x, 0f, posInt.y);
                Handles.Label(
                    pos, 
                    new GUIContent(tile.ToString()), 
                    GUIHelper.GetLabelStyle(14)
                );
            }
        }

        private void Generate() {
            GenerateTiles();
            DefineTiles();
        }

        private void GenerateTiles() {
            _generatedTiles = new();
            for (int x = 0; x < _worldSize; ++x) {
                for (int y = 0; y < _worldSize; ++y) {
                    Tile tile = new Tile(new Vector2Int(x, y));
                    _generatedTiles.Add(tile);
                }
            }
        }

        private void DefineTiles() {
            foreach (ITile tile in _generatedTiles) {
                if (tile.IsDefined())
                    continue;

                ITile tileUp = GetTileFromPosition(tile.GetPosition() + Vector2Int.up);
                ITile tileRight = GetTileFromPosition(tile.GetPosition() + Vector2Int.right);
                ITile tileDown = GetTileFromPosition(tile.GetPosition() + Vector2Int.down);
                ITile tileLeft = GetTileFromPosition(tile.GetPosition() + Vector2Int.left);

                WFCTile wfcTile = GetCorrespondingTile(tileUp, tileRight, tileDown, tileLeft);
                if (wfcTile != null)
                    tile.ID = wfcTile.ID;
            }
        }

        private WFCTile GetCorrespondingTile(ITile tileUp, ITile tileRight, ITile tileDown, ITile tileLeft) {
            IEnumerable<WFCTile> filteredTiles = _tiles;
            if (tileUp != null) 
                filteredTiles = filteredTiles.Where(tilesUp => tilesUp.up.Exists(innerTile => innerTile.ID == tileUp.ID));

            if (tileRight != null)
                filteredTiles = filteredTiles.Where(tilesRight => tilesRight.right.Exists(innerTile => innerTile.ID == tileRight.ID));

            if (tileDown != null)
                filteredTiles = filteredTiles.Where(tilesDown => tilesDown.down.Exists(innerTile => innerTile.ID == tileDown.ID));

            if (tileRight != null)
                filteredTiles = filteredTiles.Where(tilesRight => tilesRight.right.Exists(innerTile => innerTile.ID == tileRight.ID));

            if (!filteredTiles.Any()) {
                return _tiles.Find(T => T.IsEmptyTile());

                /*Debug.LogError($"No WFCTile found on generation!");
                return null;*/
            }

            int randomWFCTileIndex = (filteredTiles.Count() > 1) ? Random.Range(0, filteredTiles.Count()) : 0;
            return filteredTiles.ToList()[randomWFCTileIndex];
        }

        private ITile GetTileFromPosition(Vector2Int position) => _generatedTiles.Find(T => T.GetPosition() == position);
    }
}