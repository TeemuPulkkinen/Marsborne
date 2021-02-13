using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile
{
    
    public enum TileType
    {
        Empty,
        Floor
    }

    TileType type = TileType.Empty;

    Action<Tile> cbTileTypeChanged;

    public TileType Type { 
        get
        {
            return type;
        }
        set
        {
            TileType oldType = type;
            type = value;
            // Call the callback and let things know we've changed.
            if (cbTileTypeChanged != null && oldType != type)
            {
                cbTileTypeChanged(this);
            }
            
        }
    }
   
    LooseObject looseObject;
    InstalledObject installedObject;

    World world;
    int x;
    public int X { get => x; set => x = value; }

    int y;
    public int Y { get => y; set => y = value; }

    public Tile( World world, int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }

    public void RegisterTileTypeChangedCallback(Action<Tile> callback)
    {
        cbTileTypeChanged += callback;
    }
    public void UnRegisterTileTypeChangedCallback(Action<Tile> callback)
    {
        cbTileTypeChanged -= callback;
    }

}
