using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public Head head;
    public GameObject blockTail;
    public List<GameObject> tail;
    public Sprite emptyBelly;
    public Sprite fullBelly;
    public List<Vector3> trailFood;

    void Start()
    {
        tail = new();
        trailFood = new();
    }

    public void GrowTail()
    {
        GameObject bt = Instantiate(blockTail);
        bt.transform.parent = transform;
        tail.Add(bt);
    }

    public void MoveTail()
    {
        if(tail.Count > 0)
        {
            GameObject auxBlockTail = tail[0];
            tail.RemoveAt(0);
            tail.Add(auxBlockTail);
            tail.Last().transform.position = head.lastPosition;

            int i = trailFood.FindIndex(v => v == tail.Last().transform.position);
            
            if (i != -1)
            {
                trailFood.RemoveAt(i);
                tail.Last().GetComponent<SpriteRenderer>().sprite = fullBelly;
            }
            else
            {
                tail.Last().GetComponent<SpriteRenderer>().sprite = emptyBelly;
            }
        }
    }

    public void AddPositionFoodAtTrail(Vector3 pos)
    {
        trailFood.Add(pos);
    }

}
