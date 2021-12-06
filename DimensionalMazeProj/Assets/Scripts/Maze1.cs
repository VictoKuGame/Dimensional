using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze1 : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    private int width = 10;
    [SerializeField]
    [Range(1, 50)]
    private int height = 10;
    [SerializeField]
    private float size = 1f;
    [SerializeField]
    private Transform wallPrefab = null;
    [SerializeField]
    private Transform floorPrefab = null;
    public MazeRenderer mazeRenderer1;

    public MazeRenderer mazeRenderer2;
    // Start is called before the first frame update
    void Start()
    {
        for (int a = 0; a < width; a++)
        {
            for (int b = 0; b < height; b++)
            {
                var floor = Instantiate(floorPrefab, transform.position + new Vector3((float)a - (width / 2), 0, (float)b - (height / 2)), transform.rotation);
                floor.transform.SetParent(transform);
            }
        }
        mazeRenderer1.initMap(width,height,size,wallPrefab,floorPrefab);
        mazeRenderer2.initMap(width,height,size,wallPrefab,floorPrefab);
    }
}
