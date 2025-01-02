using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    void Start()
    {
        SetNewPosition();
    }

    public void SetNewPosition()
    {
        Vector3 newPosition = new();

        int x = Random.Range(-3, 3);
        int y = Random.Range(-3, 3);

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
            
            default:
                break;
        }
    }
}
