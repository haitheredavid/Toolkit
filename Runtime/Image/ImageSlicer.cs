using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolKit {
    public static class ImageSlicer {

        public static Texture2D[ , ] GetSlices( Texture2D image, int tilesPerLine )
            {
                int imageSize = Mathf.Min( image.width, image.height );
                int tileSize = imageSize / tilesPerLine;

                Texture2D[ , ] tiles = new Texture2D[ tilesPerLine, tilesPerLine ];

                for ( int y = 0; y < tilesPerLine; y++ ) {
                    for ( int x = 0; x < tilesPerLine; x++ ) {
                        Texture2D tile = new Texture2D( tileSize, tileSize );

                        tile.SetPixels( image.GetPixels( x * tileSize, y * tileSize, tileSize, tileSize ) );
                        tile.Apply( );

                        tiles[ x, y ] = tile;
                    }
                }

                return tiles;
            }

    }
}