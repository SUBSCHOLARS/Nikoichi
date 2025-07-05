using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteScaler : MonoBehaviour
{
    public Sprite[] sprites;
    public float scalePadding = 0.3f;
    private SpriteRenderer spriteRenderer;
    private Vector3 initialScale;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (sprites.Length == 0) return;
        Sprite chosenSprite = sprites[Random.Range(0, sprites.Length)];
        spriteRenderer.sprite = chosenSprite;
        initialScale = transform.localScale;
        CompensateForParentScale();
    }

    void CompensateForParentScale()
    {
        if (transform.parent != null)
        {
            Vector3 parentScale = transform.parent.lossyScale;

            // Calculate inverse of parent scale
            Vector3 inverseParentScale = new Vector3(
                1f / parentScale.x,
                1f / parentScale.y,
                1f / parentScale.z
            );

            // Apply padding factor (e.g., 0.93 = 93%)
            float paddingFactor = 1f - scalePadding;

            transform.localScale = new Vector3(
                initialScale.x * inverseParentScale.x * paddingFactor,
                initialScale.y * inverseParentScale.y * paddingFactor,
                initialScale.z * inverseParentScale.z * paddingFactor
            );
        }
    }

    void LateUpdate()
    {
        // Keep updating to react to parent scale changes at runtime
        CompensateForParentScale();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
