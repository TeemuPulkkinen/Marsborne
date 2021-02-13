using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    // Our tile sprite for floor
    public Sprite floorSprite;
    
    // The world and tile data
    World world;
    
    // Start is called before the first frame update
    void Start()
    {
        // Create a world with Empty tiles
        world = new World();

        // Create a GameObject for each of our tiles, so they show visually
        for (int x = 0; x < world.Width; x++)
        {
            for (int y = 0; y < world.Height; y++)
            {
                // Gets the tile data
                Tile tile_data = world.GetTileAt(x, y);

                // Creates a new GameObject and adds it to our scene
                GameObject tile_go = new GameObject();
                tile_go.name = "Tile_ " + x + "_" + y;
                tile_go.transform.position = new Vector3(tile_data.X, tile_data.Y, 0);
                tile_go.transform.SetParent(this.transform, true);

                /* 
                Add a sprite renderer, but don't bother setting a sprite
                because all the tiles are empty right now.
                */
                tile_go.AddComponent<SpriteRenderer>();

                tile_data.RegisterTileTypeChangedCallback( (tile) => { OnTileTypeChanged(tile, tile_go); } );
            }
        }

        // Randomizes the tiles in the world
        world.RandomizeTiles();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    // Checks if type of tile is Floor or Empty and uses the sprite if it is Floor
    void OnTileTypeChanged(Tile tile_data, GameObject tile_go)
    {
        if (tile_data.Type == Tile.TileType.Floor)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = floorSprite;
        }
        else if (tile_data.Type == Tile.TileType.Empty)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            Debug.LogError("OnTileTypeChanged - Unrecognized tile type.");
        }
    }
}
