using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public List<Sprite> fuitsSprites;
    public SpriteRenderer spriteRenderer;
    public TMP_Text textFruitTime;

    public float drawTime;
    public float standbyTime;
    public float currentTime;
    public bool inDraw;
    public bool inStandby;
    public int spriteIndex;
    
    public FruitCount fruitCount;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentTime = standbyTime;
        inStandby = true;
        inDraw = false;

        fruitCount = GameObject.Find("FruitsManager").GetComponent<FruitCount>();
    }

    void Update()
    {
        SwitchState();
        UpdateFruitTimeOnCanvas();
    }

    private void UpdateFruitTimeOnCanvas()
    {
        if(inDraw)
        {
            // Update do canvas
            textFruitTime.text = $"Fruit Time: {currentTime.ToString("F2")}";
        }
        else
        {
            textFruitTime.text = $"Fruit Time: {0.ToString("F2")}";
        }
    }

    public void Eat()
    {
        SendToStandby();
        fruitCount.AddFruit(spriteIndex+1);
    }

    public void SwitchState()
    {
        currentTime -= Time.deltaTime;
        if(inStandby)
        {
            if (currentTime <= 0)
            {
                currentTime = drawTime;
                DrawFruit();
                inDraw = true;
                inStandby = false;
            }
        }
        else if(inDraw)
        {
            if (currentTime <= 0)
            {
                currentTime = standbyTime;
                StandbyFruit();
                inDraw = false;
                inStandby = true;
            }

        }

    }

    public void DrawFruit()
    {
        spriteIndex = Random.Range(0, fuitsSprites.Count);
        spriteRenderer.sprite = fuitsSprites[spriteIndex];
        SetNewPosition();
    }

    public void StandbyFruit()
    {
        transform.position = new Vector3(20, 20, 0);
    }

    public void SendToStandby()
    {
        transform.position = new Vector3(20, 20, 0);
        currentTime = standbyTime;
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
