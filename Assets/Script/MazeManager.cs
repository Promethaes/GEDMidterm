using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public GameObject Tile;

    public int xDimension = 1;
    public int yDimension = 1;

    List<List<GameObject>> tiles;

    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<List<GameObject>>();

        //x is how many columns there are
        //y is how many rows there are

        for (int i = 0; i < yDimension; i++)
        {
            tiles.Add(new List<GameObject>());
            for (int j = 0; j < xDimension; j++)
            {
                tiles[i].Add(GameObject.Instantiate(Tile));
                tiles[i][j].transform.position = new Vector3(i, 0.0f, j);
            }
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}
