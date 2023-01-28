using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PlinioJRM.Helpers {

    public static class Helper {
        /// <summary>
        /// Wait for seconds cleaner for garbage collector
        /// </summary>
        private static readonly Dictionary<float, WaitForSeconds> _waitDictionary = new();
        public static WaitForSeconds GetWait(float time) {
            if (_waitDictionary.TryGetValue(time, out WaitForSeconds wait))
                return wait;

            _waitDictionary[time] = new(time);
            return _waitDictionary[time];
        }

        private static PointerEventData _eventDataCurrentPosition;
        private static List<RaycastResult> _results;
        public static bool IsOverUI() {
            _eventDataCurrentPosition = new(EventSystem.current) {
                position = Input.mousePosition
            };
            _results = new();
            EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);

            return _results.Count > 0;
        }
    }
}