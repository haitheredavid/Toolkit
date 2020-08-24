using UnityEngine;

namespace ToolKit {
    public class TileGrid  : AGrid{
        
        protected SpriteRenderer[ , ] _tileArray;

        public TileGrid( int width, int height, float tileSize, Vector3 origin ) : base( width, height, tileSize, origin )
            {
                _tileArray = new SpriteRenderer[ width, height ];

            }

   
        public void CreateTileArray( )
            {
                if ( _tileSize > 0 ) {
                    // get size 
                    int size = (int) _tileSize * 100;
                    // build pixel
                    Color[ ] tileColor = new Color[ size * size ];
                    for ( int i = 0; i < tileColor.Length; i++ )
                        tileColor[ i ] = Color.white;

                    // build texture 
                    var texture = new Texture2D( size, size );
                    texture.SetPixels( tileColor );
                    texture.Apply( );

                    // editor objects
                    if ( _container != null )
                        Object.Destroy( _container );

                    _container = new GameObject( "tile container" );

                    var tilePrefab = new GameObject( );
                    tilePrefab.AddComponent<SpriteRenderer>( );
                    // move through grid
                    for ( int x = 0; x < _gridArray.GetLength( 0 ); x++ ) {
                        for ( int y = 0; y < _gridArray.GetLength( 1 ); y++ ) {
                            var instance = Object.Instantiate( tilePrefab, _container.transform );
                            instance.name = x + " " + y;

                            var tempSprite = Sprite.Create( texture, new Rect( 0, 0, texture.width, texture.height ), Vector3.one * 0.5f );
                            instance.GetComponent<SpriteRenderer>( ).sprite = tempSprite;
                            instance.transform.position = GetTileCenter( x, y );
                            _tileArray[ x, y ] = instance.GetComponent<SpriteRenderer>( );
                        }
                    }

                    Utilities.SafeDestroy( tilePrefab );
                } else {
                    Debug.Log( "Tile size is 0" );
                }
            }
        public void SetTileActive( bool status, int x, int y )
            {
                if ( x >= 0 && y >= 0 && x < _width && y < _height ) {
                    _tileArray[ x, y ].enabled = status;
                }
            }
        public void SetTileColor( Color32[ ] colors )
            {
                // check if tiles are created
                if ( _container == null )
                    CreateTileArray( );

                Color32 c = new Color32( );

                for ( int x = 0, i = 0; x < _tileArray.GetLength( 0 ); x++ ) {
                    for ( int y = 0; y < _tileArray.GetLength( 1 ); y++, i++ ) {
                        if ( i < colors.Length ) {
                            c = colors[ i ];
                        }
                        _tileArray[ x, y ].color = c;
                    }
                }
            }
    }
}