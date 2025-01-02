using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public List<GameObject> tail;
    public GameObject blockTail;
    public Head head;
    void Start()
    {
        tail = new();
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
        }
    }

}
