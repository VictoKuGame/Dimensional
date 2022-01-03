using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
    public Transform light;
    public Transform player;





    public NavMeshSurface surface;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] locations = new Vector3[4];
        locations[0] = new Vector3(-(width / 2), 0, -(height / 2));
        locations[1] = new Vector3((width / 2), 0, (height / 2));
        locations[2] = new Vector3(-(width / 2), 0, (height / 2));
        locations[3] = new Vector3((width / 2), 0, -(height / 2));
        for (int a = 0; a <= width; a++)
        {
            for (int b = 0; b <= height; b++)
            {
                var floor = Instantiate(floorPrefab, transform.position + new Vector3((float)a - (width / 2), 0, (float)b - (height / 2)), transform.rotation);
                floor.transform.SetParent(transform);
            }
        }
        player.position = locations[UnityEngine.Random.Range(0, locations.Length)];
        generateAnotherOne(true, false);
        Instantiate(light, transform.position + locations[0], Quaternion.Euler(22.5f, 45, 0)).transform.SetParent(transform);
        Instantiate(light, transform.position + locations[1], Quaternion.Euler(22.5f, 225, 0)).transform.SetParent(transform);
        Instantiate(light, transform.position + locations[2], Quaternion.Euler(22.5f, 135, 0)).transform.SetParent(transform);
        Instantiate(light, transform.position + locations[3], Quaternion.Euler(22.5f, -45, 0)).transform.SetParent(transform);
        generateAnotherOne(false, true);
        surface.BuildNavMesh();
    }
    public void generateAnotherOne(bool newMaze01, bool newMaze02)
    {
        if (newMaze01)
        {
            mazeRenderer1.initMap(width, height, size, wallPrefab, floorPrefab);
        }
        if (newMaze02)
        {
            mazeRenderer2.initMap(width, height, size, wallPrefab, floorPrefab);
        }
    }
}





