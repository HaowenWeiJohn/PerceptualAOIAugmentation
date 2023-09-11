using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyFadingEffect : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parent;
    public float fadeDuration = 1.0f;
    public float copyInterval = 0.3f; // Call the coroutine every y seconds

    private float timeSinceLastCall = 0f;

    private void Update()
    {
        timeSinceLastCall += Time.deltaTime;

        if (timeSinceLastCall >= copyInterval)
        {
            timeSinceLastCall = 0f;
            StartCoroutine(FadeAndDestroyCoroutine());
        }
    }

    private IEnumerator FadeAndDestroyCoroutine()
    {
        if(gameObject.tag == "Moving")
        {
            // Create a copy of the target object
            GameObject copy = Instantiate(prefab, transform.position, transform.rotation, parent.transform);

            // Get the renderer and initial color of the copy
            Renderer copyRenderer = copy.transform.GetChild(0).gameObject.GetComponent<Renderer>();
            Color initialColor = copyRenderer.material.color;

            // Gradually fade the copy's alpha to 0 over fadeDuration seconds
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
                Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
                copyRenderer.material.color = newColor;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the copy's alpha is 0 and destroy it
            Color finalColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);
            copyRenderer.material.color = finalColor;
            Destroy(copy);
        }
    }
}
