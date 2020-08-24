using UnityEngine;

namespace ToolKit {
public class SimpleBounds {

    public Vector3 TLeft;
    public Vector3 TRight;

    public Vector3 BLeft;
    public Vector3 BRight;

    public float Size;

    public Vector3 Center => new Vector3( ( TLeft.x + BRight.x ) * 0.5f, ( TLeft.y + BRight.y ) * 0.5f, ( TLeft.z + BRight.z ) / 2 );

}

public abstract class AGrid {

    public const int HeadMapMaxValue = 100;
    public const int HeatMapMinValue = 0;

    protected int _width;
    protected int _height;
    protected float _tileSize;
    protected Vector3 _origin;
    protected int[ , ] _gridArray;
    protected GameObject _container;

    protected SimpleBounds _bounds;

    protected AGrid( int width, int height, float tileSize, Vector3 origin )
        {
            _width = width;
            _height = height;
            _tileSize = tileSize;
            _origin = origin;
            _gridArray = new int[ width, height ];

            Debug.Log( width + " " + height );
        }

    public Vector3 GetCenter => _bounds.Center;
    public int GetTileCount => _width * _height;

    public Vector3 GetContainerOrigin => _container == null ? _origin : _container.transform.position;

    protected Vector3 GetTileCenter( int x, int y )
        {
            return GetWorldPosition( x, y ) + new Vector3( _tileSize, _tileSize ) * 0.5f;
        }
    protected void GetXY( Vector3 worldPos, out int x, out int y )
        {
            x = Mathf.FloorToInt( ( worldPos - GetContainerOrigin ).x / _tileSize );
            y = Mathf.FloorToInt( ( worldPos - GetContainerOrigin ).y / _tileSize );
        }

    protected SimpleBounds SetBounds( float width, float height, float size )
        {
            var tempOrigin = GetContainerOrigin;
            return new SimpleBounds {
                Size = size,
                BLeft = tempOrigin,
                BRight = new Vector3( tempOrigin.x, tempOrigin.y + height, tempOrigin.z ),
                TLeft = new Vector3( tempOrigin.x + width, tempOrigin.y, tempOrigin.z ),
                TRight = new Vector3( tempOrigin.x + width, tempOrigin.y + height, tempOrigin.z )
            };
        }

    public float GetBoundsSize {
        get
        {
            float size = 1f;
            if ( _bounds != null )
                size = _bounds.Size;
            return size;
        }
    }

    public Vector3 GetWorldPosition( int x, int y )
        {
            return new Vector3( x, y ) * _tileSize + GetContainerOrigin;
        }

    public virtual Vector3[ ] GetAllCenters( )
        {
            var count = GetTileCount;
            Vector3[ ] tempPos = new Vector3[ count ];
            for ( int x = 0, i = 0; x < _gridArray.GetLength( 0 ); x++ ) {
                for ( int y = 0; y < _gridArray.GetLength( 1 ); y++, i++ ) {
                    if ( i >= count ) continue;

                    tempPos[ i ] = GetTileCenter( x, y );
                }
            }
            return tempPos;
        }
    public int GetValue( int x, int y )
        {
            if ( x >= 0 && y >= 0 && x < _width && y < _height )
                return _gridArray[ x, y ];
            else
                return 0;
        }

    public int GetValue( Vector3 worldPos )
        {
            GetXY( worldPos, out int x, out int y );
            return GetValue( x, y );
        }
    public void SetValue( int x, int y, int value )
        {
            if ( x >= 0 && y >= 0 && x < _width && y < _height ) {
                _gridArray[ x, y ] = Mathf.Clamp( HeatMapMinValue, HeadMapMaxValue, value );
            }
        }

    public void SetValue( Vector3 worldPosition, int value )
        {
            GetXY( worldPosition, out int x, out int y );
            SetValue( x, y, value );
        }

    public void SetParent( GameObject flagContainer )
        {
            if ( _container != null )
                _container.transform.SetParent( flagContainer.transform );
        }

    public void SetContainerPosition( Vector3 pos )
        {
            if ( _container != null )
                _container.transform.position = pos;
        }
    }
}