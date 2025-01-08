using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public bool sineEffectActive;
    public float speedSineEffect;
    public float currentAngle;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        SineEffect();
    }

    private void SineEffect()
    {
        if (sineEffectActive && (spriteRenderer != null))
        {
            currentAngle += Time.deltaTime * speedSineEffect;
            if(currentAngle > 359)
            {
                currentAngle = 0.0f;
            }
            spriteRenderer.color = new Color(1.0f,1.0f,1.0f,NormalizedSine(currentAngle));
        }
    }

    public float NormalizedSine(float angle)
    {
        // Calcula o seno em radianos e normaliza para o intervalo 0 a 1
        float sineValue = Mathf.Sin(angle * Mathf.Deg2Rad);
        return (sineValue + 1) / 2;
    }
}
