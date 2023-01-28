using UnityEngine;

namespace PlinioJRM.World {
    public class Tile : ITile {
        private Vector2Int _position;
        private int _id;
        private TileStatus _status;

        public Tile(Vector2Int position) { 
            _position = position;
            _status = TileStatus.Undefined;
        }

        public bool IsDefined() => _status == TileStatus.Set;
        public Vector2Int GetPosition() => _position;

        public int ID {
            get => _id;
            set {
                if (IsDefined())
                    return;

                _id = value;
                ++_status;
            }
        }

        public override string ToString() => $"{_id}\n({_position.x},{_position.y})";
    }
}