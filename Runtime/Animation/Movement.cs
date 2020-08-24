using UnityEngine;

namespace ToolKit {
    public static class Movement {
        
        public static Vector3 SmoothMove( Vector3 curValue, Vector3 targetValue, float smooth = 1f, float speed = 1f )
            {
                curValue += ( targetValue - curValue ) * smooth / speed;
                return curValue;
            }
        
        
        public static float SmoothMove( float curValue, float targetValue, float smooth = 1f, float speed = 1f )
            {
                curValue += ( targetValue - curValue ) * smooth / speed;
                return curValue;
            }



        
        
        

    }
}