using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public List<Sprite> fuitsSprites;
    public SpriteRenderer spriteRenderer;

    public float drawTime;
    public float standbyTime;
    public float currentTime;
    public bool inDraw;
    public bool inStandby;
    
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentTime = 0.0f;
        inStandby = true;
        inDraw = false;
    }

    void Update()
    {
        SwitchState();
    }

    public void SwitchState()
    {
        currentTime += Time.deltaTime;
        if(inStandby)
        {
            if (currentTime >= drawTime)
            {
                currentTime = 0.0f;
                DrawFruit();
                inDraw = true;
                inStandby = false;
            }
        }
        else if(inDraw)
        {
            if (currentTime >= standbyTime)
            {
                currentTime = 0.0f;
                StandbyFruit();
                inDraw = false;
                inStandby = true;
            }

        }

    }

    public void DrawFruit()
    {
        int i = Random.Range(0, fuitsSprites.Count);
        spriteRenderer.sprite = fuitsSprites[i];
        SetNewPosition();
    }

    public void StandbyFruit()
    {
        transform.position = new Vector3(20, 20, 0);
    }

    public void SendToStandby()
    {
        transform.position = new Vector3(20, 20, 0);
        currentTime = 0.0f;
        inStandby = true;
        inDraw = false;
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
            
            case "Food":
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
