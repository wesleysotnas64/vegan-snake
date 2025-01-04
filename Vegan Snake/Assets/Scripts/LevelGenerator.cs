using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject bush;

    void Start()
    {
        GenerateHorizontalLineBushWall(-10, 10,  8);
        GenerateHorizontalLineBushWall(-10, 10, -8);
    }


    public void GenerateHorizontalLineBushWall(int initX, int finalX, int heightY)
    {
        for(int x = initX; x <= finalX; x++)
        {
            Instantiate(bush).transform.position = new Vector3(x, heightY, 0);
        }
    }
}
