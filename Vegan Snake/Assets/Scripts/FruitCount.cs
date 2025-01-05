using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitCount : MonoBehaviour
{
    public int[] fruitsQuantity;
    public List<TMP_Text> textFruitsQuantity;
    void Start()
    {
        fruitsQuantity = new int[8];
        UpdatePanelFruitOnCanvas();
    }

    public void AddFruit(int fruit)
    {
        fruitsQuantity[fruit]++;
        UpdatePanelFruitOnCanvas();
    }

    private void UpdatePanelFruitOnCanvas()
    {
        for(int i = 0; i < textFruitsQuantity.Count; i++)
        {
            textFruitsQuantity[i].text = $" X {fruitsQuantity[i]}";
        }
    }
}
