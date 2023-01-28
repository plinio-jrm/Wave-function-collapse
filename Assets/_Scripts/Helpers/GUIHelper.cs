using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlinioJRM.Helpers {
    public static class GUIHelper {
        public static GUIStyle GetLabelStyle(int fontSize = 20) {
            GUIStyle style = new GUIStyle() {
                fontSize = fontSize,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
            };
            return style;
        }
    }
}