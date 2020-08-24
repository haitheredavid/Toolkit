using System;
using UnityEngine;

namespace ToolKit{
public sealed class GridSource : ScriptableObject {

    [SerializeField] public int width = 6;
    [SerializeField] public int height = 6;
    [SerializeField] public float size = 10f;
    [SerializeField] public Vector3[ ] tileCenters;
    
    [SerializeField] public TileGrid[ ] FlagTiles;
    
    [SerializeField] public TileGrid redTiles;
    [SerializeField] public TileGrid orangeTiles;
    [SerializeField] public TileGrid blueTiles;
    [SerializeField] public TileGrid purpleTiles;
    [SerializeField] public TileGrid yellowTiles;
    [SerializeField] public TileGrid greenTiles;

    public TileGrid[ ] GetTiles( )
        {
            return FlagTiles;
        }
    public Vector3[ ] GetCenters( )
        {
            return tileCenters;
        }

    public void Initialize( int w, int h, float s )
        {
            width = w;
            height = h;
            size = s;
        }
    
    public void SetTiles( TileGrid[ ] tiles )
        {
            FlagTiles = new TileGrid[ tiles.Length ];
    
            for ( var i = 0; i < tiles.Length; i++ ) {
                FlagTiles[ i ] = tiles[ i ];
            }
        }


    public int GetTileCount( int i )
        {
            int tempCount = 0;
            switch ( i ) {
                case ColorWorld.RainbowArraySix.RedIndex:
                    tempCount = redTiles.GetTileCount;
                    break;
                case ColorWorld.RainbowArraySix.OrangeIndex:
                    tempCount = orangeTiles.GetTileCount;
                    break;
                case ColorWorld.RainbowArraySix.YellowIndex:
                    tempCount = yellowTiles.GetTileCount;
                    break;
                case ColorWorld.RainbowArraySix.GreenIndex:
                    tempCount = greenTiles.GetTileCount;
                    break;
                case ColorWorld.RainbowArraySix.BlueIndex:
                    tempCount = blueTiles.GetTileCount;
                    break;
                case ColorWorld.RainbowArraySix.PurpleIndex:
                    tempCount = purpleTiles.GetTileCount;
                    break;
            }
            return tempCount;
        }
    }
}