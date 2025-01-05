using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject bush;

    void Start()
    {
        TestLevel();
    }

    private void TestLevel()
    {
        GenerateHorizontalLineBushWall(-10, 10,  8);
        GenerateHorizontalLineBushWall(-10, 10, -8);
        GenerateVerticalLineBushWall(-7, 7, -10);
        GenerateVerticalLineBushWall(-7, 7, 10);
    }

    public void GenerateHorizontalLineBushWall(int initX, int finalX, int heightY)
    {
        for(int x = initX; x <= finalX; x++)
        {
            Instantiate(bush).transform.position = new Vector3(x, heightY, 0);
        }
    }
    public void GenerateVerticalLineBushWall(int initY, int finalY, int distX)
    {
        for(int y = initY; y <= finalY; y++)
        {
            Instantiate(bush).transform.position = new Vector3(distX, y, 0);
        }
    }
}
