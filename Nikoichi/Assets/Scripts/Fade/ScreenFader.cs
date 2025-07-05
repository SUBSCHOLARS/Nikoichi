using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScreenFader : MonoBehaviour
{
    public GameObject RedScreen;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FadeInAndOut()
    {
        RedScreen.SetActive(true);
        spriteRenderer = RedScreen.GetComponent<SpriteRenderer>();

        float startAlpha = 115f / 255f;
        float endAlpha = 160f / 255f;

        var initialColor = spriteRenderer.color;
        initialColor.a = startAlpha;
        spriteRenderer.color = initialColor;

        spriteRenderer.DOFade(endAlpha, 1.0f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
