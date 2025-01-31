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
    public bool moveIsActie;
    public Tail tail;
    public Food food;
    public Fruit fruit;
    public GameObject zzzzz;

    void Start()
    {
        currentTime = 0.0f;
        moveIsActie = false;
    }

    void Update()
    {
        SelectDirection();
        Move();
    }

    public void SelectDirection()
    {
        if(moveIsActie)
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
            transform.up = moveIsActie ? direction : new Vector3(0,-1,0);

            tail.MoveTail();
        }
    }

    private void EatFood()
    {
        tail.AddPositionFoodAtTrail(food.transform.position);
        tail.GrowTail();
        food.Eat();
    }

    private void EatFruit()
    {
        tail.AddPositionFoodAtTrail(fruit.transform.position);
        tail.GrowTail();
        fruit.Eat();
    }

    private void StopMove()
    {
        direction = Vector3.zero;
        moveTime = 0.03f;
        transform.up = new Vector3(0,-1,0);
        moveIsActie = false;
        CloseMounth();
        zzzzz.transform.position = transform.position;
    }

    public void OpenMounth()
    {
        if(moveIsActie)
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
