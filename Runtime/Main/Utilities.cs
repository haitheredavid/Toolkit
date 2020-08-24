using UnityEngine;

namespace ToolKit {
    public static class Utilities {

        /// <summary>
        /// Get mouse pos in world with 0f
        /// </summary>
        /// <returns></returns>
        public static Vector3 GetMouseWorldPos( )
            {
                Vector3 vec = GetMouseWorldPositionWithZ( Input.mousePosition, Camera.main );
                vec.z = 0f;
                return vec;
            }

        public static Vector3 GetMouseWorldPositionWithZ( )
            {
                return GetMouseWorldPositionWithZ( Input.mousePosition, Camera.main );
            }

        public static Vector3 GetMouseWorldPositionWithZ( Vector3 mousePosition )
            {
                return GetMouseWorldPositionWithZ( Input.mousePosition, Camera.main );
            }
        public static Vector3 GetMouseWorldPositionWithZ( Vector3 mousePosition, Camera camera )
            {
                Vector3 worldPos = camera.ScreenToWorldPoint( mousePosition );
                return worldPos;
            }
        
        public static void SafeDestroy( Object obj )
            {
                if ( Application.isEditor )
                    Object.DestroyImmediate( obj );
                else
                    Object.Destroy( obj );
            }

    }
}