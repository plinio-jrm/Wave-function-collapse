using UnityEngine;

namespace PlinioJRM.World {
    public interface ITile {
        bool IsDefined();
        Vector2Int GetPosition();
        int ID { get; set; }
        string ToString();
    }
}