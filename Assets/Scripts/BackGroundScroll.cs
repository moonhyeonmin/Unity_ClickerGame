using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 500f;
    const float backgroundPositionY = 480f;
    const float backgroundOutPositionX = -720f;
    const float backgroundStartPositionX = 1440f;

    public Image[] backgroundSprite;
    float[] backgroundOffset;
    void Start()
    {
        Debug.Log("deltaTime: " + Time.deltaTime);
        InitBackgroundSpritePosition();
    }

    private void Update()
    {
        MoveBackgroundSpritePosition();
    }

    void InitBackgroundSpritePosition()
    {
        backgroundOffset = new float[backgroundSprite.Length];

        for (int i = 0; i < backgroundSprite.Length; i++)
        {
            backgroundOffset[i] = backgroundSprite[i].rectTransform.localPosition.x;
        }
    }

    void MoveBackgroundSpritePosition()
    {
        for (int i = 0; i < backgroundSprite.Length; i++)
        {
            backgroundOffset[i] -= Time.deltaTime * scrollSpeed;
            backgroundSprite[i].rectTransform.localPosition = new Vector3(backgroundOffset[i], backgroundPositionY);

            if (backgroundSprite[i].rectTransform.localPosition.x <= backgroundOutPositionX)
            {
                backgroundSprite[i].rectTransform.localPosition = new Vector3(backgroundStartPositionX, backgroundPositionY);
                backgroundOffset[i] = backgroundSprite[i].rectTransform.localPosition.x;
            }
        }
    }

    public void SetScrollSpeed(float setSpeed)
    {
        scrollSpeed = setSpeed;
    }
}
