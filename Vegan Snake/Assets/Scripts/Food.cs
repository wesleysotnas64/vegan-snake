using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public FruitCount fruitCount;

    void Start()
    {
        SetNewPosition();
        fruitCount = GameObject.Find("FruitsManager").GetComponent<FruitCount>();
    }

    public void Eat()
    {
        SetNewPosition();
        fruitCount.AddFruit(0);
    }

    public void SetNewPosition()
    {
        Vector3 newPosition = new();

        int x = Random.Range(-15, 7);
        int y = Random.Range(-8, 6);

        newPosition.x = x;
        newPosition.y = y;
        newPosition.z = 0;

        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;

        switch(tag)
        {
            case "Tail":
                SetNewPosition();
                break;

            case "Fruit":
                SetNewPosition();
                break;

            case "Wall":
                SetNewPosition();
                break;
            
            default:
                break;
        }
    }
}
