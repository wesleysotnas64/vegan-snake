using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Sprite headCloseMounth; //Default
    public Sprite headOpenMounth; //Open Mounth
    public Vector3 direction;
    public Vector3 lastDirection;
    public Vector3 lastPosition;
    public float moveTime;
    public float currentTime;
    public Tail tail;
    public Food food;
    public Fruit fruit;

    void Start()
    {
        currentTime = 0.0f;
    }

    void Update()
    {
        SelectDirection();
        Move();
    }

    public void SelectDirection()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            direction = new Vector3(0, 1, 0);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            direction = new Vector3(0, -1, 0);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            direction = new Vector3(1, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            direction = new Vector3(-1, 0, 0);
        }
    }

    public void Move()
    {
        currentTime += Time.deltaTime;
        if(currentTime > moveTime)
        {
            if(direction == -lastDirection)
            {
                direction *= -1;
            }

            currentTime = 0;
            lastDirection = direction;
            lastPosition = transform.position;
            transform.position += direction;
            transform.up = direction;

            tail.MoveTail();
        }
    }

    private void EatFood()
    {
        tail.AddPositionFoodAtTrail(food.transform.position);
        tail.GrowTail();
        food.SetNewPosition();
    }

    private void EatFruit()
    {
        tail.AddPositionFoodAtTrail(fruit.transform.position);
        tail.GrowTail();
        fruit.SendToStandby();
    }

    private void StopMove()
    {
        direction = Vector3.zero;
        // moveTime *= 0.5f;
    }

    public void OpenMounth()
    {
        GetComponent<SpriteRenderer>().sprite = headOpenMounth;
    }

    public void CloseMounth()
    {
        GetComponent<SpriteRenderer>().sprite = headCloseMounth;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;

        switch(tag)
        {
            case "Food":
                EatFood();
                break;

            case "Fruit":
                EatFruit();
                break;

            case "Wall":
                StopMove();
                break;

            case "Tail":
                StopMove();
                break;
            
            default:
                break;
        }
    }
}
