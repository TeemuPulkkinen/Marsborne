using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile
{
    //Lists different tile types in the game, empty and floor
    public enum TileType
    {
        Empty,
        Floor
    }

    TileType type = TileType.Empty;

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
    
    // LooseObject is something like a drill or a stack of metal sitting on the floor
    LooseObject looseObject;

    // InstalledObject is something like a wall, door or sofa
    InstalledObject installedObject;

    // We need to know the context in which we exist
    World world;
    int x;
    public int X { get => x; protected set => x = value; }

    int y;
    public int Y { get => y; protected set => y = value; }

    Action<Tile> cbTileTypeChanged;

    public Tile( World world, int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }

    // Registers a function to be called back when tile type changes
    public void RegisterTileTypeChangedCallback(Action<Tile> callback)
    {
        cbTileTypeChanged += callback;
    }

    // Unregister a callback
    public void UnRegisterTileTypeChangedCallback(Action<Tile> callback)
    {
        cbTileTypeChanged -= callback;
    }

}
