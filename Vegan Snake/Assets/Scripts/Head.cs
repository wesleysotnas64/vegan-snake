using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Vector3 direction;
    public Vector3 lastDirection;
    public Vector3 lastPosition;
    public float moveTime;
    public float currentTime;
    public Tail tail;
    public Food food;

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
        tail.GrowTail();
        food.SetNewPosition();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;

        switch(tag)
        {
            case "Food":
                EatFood();
                break;
            
            default:
                break;
        }
    }
}
