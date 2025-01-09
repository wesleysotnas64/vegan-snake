using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitCount : MonoBehaviour
{
    public int[] fruitsQuantity;
    public List<TMP_Text> textFruitsQuantity;
    public TMP_Text textScore;
    public int totalScore;

    void Start()
    {
        fruitsQuantity = new int[8];
        totalScore = 0;

        UpdateScoreOnCanvas();
        UpdatePanelFruitOnCanvas();
    }

    public void AddFruit(int fruit)
    {
        fruitsQuantity[fruit]++;
        if(fruit == 0) totalScore++;
        else totalScore += 10;

        UpdateScoreOnCanvas();
        UpdatePanelFruitOnCanvas();
    }

    private void UpdatePanelFruitOnCanvas()
    {
        for(int i = 0; i < textFruitsQuantity.Count; i++)
        {
            textFruitsQuantity[i].text = $" x {fruitsQuantity[i]}";
        }
    }

    private void UpdateScoreOnCanvas()
    {
        textScore.text = $"Score: {totalScore}";
    }
}
