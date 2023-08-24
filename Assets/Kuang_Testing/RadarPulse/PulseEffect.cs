using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseEffect : MonoBehaviour
{
     public float targetSize = 1.5f;    // Target size for the object
    public float duration = 1f;      // Duration of the animation
    public float pauseDuration = 0.5f; // Duration to pause between repetitions
    public float initialDelay = 0.25f;  // Initial delay before the animation starts

    private SpriteRenderer spriteRenderer;
    private Vector3 initialScale;
    private Color initialColor;
    private bool isFirstIteration = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialScale = transform.localScale;
        initialColor = spriteRenderer.color;

        StartCoroutine(AnimateEnlargingAndFadingRepeatedly());
    }

    private IEnumerator AnimateEnlargingAndFadingRepeatedly()
    {
        if (isFirstIteration)
        {
            yield return new WaitForSeconds(initialDelay);
            isFirstIteration = false;
        }

        while (true)
        {
            float startTime = Time.time;

            while (Time.time - startTime < duration)
            {
                float t = (Time.time - startTime) / duration;

                // Calculate the new size and alpha value
                float newSize = Mathf.Lerp(initialScale.x, targetSize, t);
                Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, Mathf.Lerp(initialColor.a, 0f, t));

                // Apply the new size and color to the object
                transform.localScale = new Vector3(newSize, newSize, transform.localScale.z);
                spriteRenderer.color = newColor;

                yield return null;
            }

            // Set the final size and alpha value
            transform.localScale = new Vector3(targetSize, targetSize, transform.localScale.z);
            spriteRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);

            // Pause between repetitions
            yield return new WaitForSeconds(pauseDuration);
        }
    }
}
