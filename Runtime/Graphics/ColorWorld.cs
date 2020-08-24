using System;
using UnityEngine;

namespace ToolKit {
    public static class ColorWorld {

        public static class RainbowArraySix {

            public const int RedIndex = 0;
            public const int OrangeIndex = 1;
            public const int YellowIndex = 2;
            public const int GreenIndex = 3;
            public const int BlueIndex = 4;
            public const int PurpleIndex = 5;

            public static Color32 Red => RainbowArray[ RedIndex ];
            public static Color32 Orange => RainbowArray[ OrangeIndex ];
            public static Color32 Yellow => RainbowArray[ YellowIndex ];
            public static Color32 Green => RainbowArray[ GreenIndex ];
            public static Color32 Blue => RainbowArray[ BlueIndex ];
            public static Color32 Purple => RainbowArray[ PurpleIndex ];

            public static int Size => RainbowArray.Length;
            public static byte alpha => 125;

            public static readonly Color32[ ] RainbowArray = {
                new Color32( 255, 0, 0, alpha),
                new Color32( 255, 127, 0, alpha),
                new Color32( 255, 255, 0, alpha),
                new Color32( 0, 255, 0, alpha),
                new Color32( 0, 0, 255, alpha),
                new Color32( 148, 0, 211, alpha)
            };

          
        }

    }
}