using UnityEngine;

namespace PlinioJRM.Helpers {
    public static class CameraHelper {
        private static Camera _mainCamera;
        public static Camera Main {
            get {
                if (_mainCamera == null)
                    _mainCamera = Camera.main;
                return _mainCamera;
            }
        }
    }
}