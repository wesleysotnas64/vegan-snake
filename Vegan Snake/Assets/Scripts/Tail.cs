using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{

    public List<GameObject> tail;
    public Head head;
    void Start()
    {
        tail = new();
    }

    // public void GrowTail()
    // {

    // }

    // public void MoveTail()
    // {
    //     if(tail.Count > 0)
    //     {
    //         tail.RemoveAt(0);
    //         tail.Add()
    //     }
    // }

}
