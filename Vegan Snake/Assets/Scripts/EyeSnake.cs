using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSnake : MonoBehaviour
{
    public Head head;

    void OnTriggerEnter2D(Collider2D col)
    {
        head.OpenMounth();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        head.CloseMounth();
    }
}
