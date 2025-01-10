using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Range(0, 100)]
    public int percentageGrass;
    public GameObject bush;
    public List<GameObject> grass;

    void Start()
    {
        // TestLevel();
        Level_02();
    }

    private void TestLevel()
    {
        GenerateHorizontalLineBushWall(-16, 8,  7);
        GenerateHorizontalLineBushWall(-16, 8, -9);
        GenerateVerticalLineBushWall(-8, 6, -16);
        GenerateVerticalLineBushWall(-8, 6, 8);

        GenerateRandomGrass(new Vector2(-15,-8), new Vector2(7, 6));
    }

    private void Level_01()
    {
        GenerateHorizontalLineBushWall(-16, 8,  7);
        GenerateHorizontalLineBushWall(-16, 8, -9);
        GenerateVerticalLineBushWall(-8, 6, -16);
        GenerateVerticalLineBushWall(-8, 6, 8);

        GenerateRandomGrass(new Vector2(-15,-8), new Vector2(7, 6));
    }

    private void Level_02()
    {
        GenerateHorizontalLineBushWall(-16, 8,  7);
        GenerateHorizontalLineBushWall(-16, 8, -9);
        GenerateVerticalLineBushWall(-8, 6, -16);
        GenerateVerticalLineBushWall(-8, 6, 8);

        GeneratePointBush(-10, 0);
        GeneratePointBush(-10, 1);
        GeneratePointBush(-9, 0);
        GeneratePointBush(-9, 1);

        GenerateRandomGrass(new Vector2(-15,-8), new Vector2(7, 6));
    }

    private void GeneratePointBush(int xPosition, int yPosition)
    {
        GameObject go = Instantiate(bush);
        go.transform.position = new Vector3(xPosition, yPosition, 0);
        go.transform.parent = transform;

    }

    private void GenerateHorizontalLineBushWall(int initX, int finalX, int heightY)
    {
        for(int x = initX; x <= finalX; x++)
        {
            GameObject go = Instantiate(bush);
            go.transform.position = new Vector3(x, heightY, 0);
            go.transform.parent = transform;
        }
    }
    private void GenerateVerticalLineBushWall(int initY, int finalY, int distX)
    {
        for(int y = initY; y <= finalY; y++)
        {
            GameObject go = Instantiate(bush);
            go.transform.position = new Vector3(distX, y, 0);
            go.transform.parent = transform;
        }
    }

    private void GenerateRandomGrass(Vector2 init, Vector2 end)
    {
        // Percorre todo o campo
        for(int x = (int)init.x; x <= end.x; x++)
        {
            for (int y = (int)init.y; y <= end.y; y++)
            {
                // Probabilidade de ser instanciado
                if(Random.Range(0, 100) > percentageGrass)
                {
                    GameObject go = Instantiate(grass[Random.Range(0, grass.Count)]);
                    go.transform.position = new Vector3(x, y, 0);
                    go.transform.parent = transform;
                }
            }
        }
    }
}
