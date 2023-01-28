using PlinioJRM.Helpers;
using UnityEditor;
using UnityEngine;

namespace PlinioJRM.WFC {
    public class WFCPrefabInfo : MonoBehaviour {
        public WFCTile tile;

        private void OnDrawGizmos() {
            if (tile == null)
                return;

            int x = (int) transform.position.x;
            int y = (int) transform.position.z;
            Handles.Label(
                transform.position,
                new GUIContent($"{tile.ID}\n({x},{y})"),
                GUIHelper.GetLabelStyle()
            );
        }
    }
}