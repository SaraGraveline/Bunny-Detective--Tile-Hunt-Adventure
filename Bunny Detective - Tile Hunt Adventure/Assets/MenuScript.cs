using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Material tileMaterial;
    public Material specialTileMaterial;
    public int numberOfTiles = 341;

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        for (int i = 0; i < tiles.Length; i++)
        {
            Renderer renderer = tiles[i].GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = tileMaterial;
            }
        }

        
        GameObject specialTile = GameObject.FindGameObjectWithTag("SpecialTile");
        if (specialTile != null)
        {
            Renderer renderer = specialTile.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = specialTileMaterial;
            }
        }
    }
}
