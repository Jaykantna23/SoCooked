using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // For UI elements

public class LoseEffect : MonoBehaviour
{
    public Camera mainCamera;         // Reference to the camera
    public Text youLostText;          // Reference to the "You Lost" text
    public float zoomOutSpeed = 10f;  // Speed at which the camera zooms out
    public float targetFOV = 90f;     // Target Field of View for the camera
    public float delayBeforeText = 2f; // Delay before showing "You Lost"
    private bool isZoomingOut = false;

    void Start()
    {
        youLostText.enabled = false;  // Hide the text at the start
    }

    // Call this method when the player loses
    public void TriggerLoseEffect()
    {
        isZoomingOut = true; // Start the zoom-out process
    }

    void Update()
    {
        if (isZoomingOut)
        {
            // Smoothly increase the camera's field of view
            if (mainCamera.fieldOfView < targetFOV)
            {
                mainCamera.fieldOfView += zoomOutSpeed * Time.deltaTime;
            }
            else
            {
                isZoomingOut = false; // Stop zooming once the target FOV is reached
                StartCoroutine(ShowLostText());
            }
        }
    }

    private IEnumerator ShowLostText()
    {
        // Wait for the delay before showing the text
        yield return new WaitForSeconds(delayBeforeText);

        // Show the "You Lost" text
        youLostText.enabled = true;

        // Optionally, you can fade the text in (example below)
        StartCoroutine(FadeInText(youLostText, 1f)); // 1-second fade-in duration
    }

    private IEnumerator FadeInText(Text text, float duration)
    {
        float elapsedTime = 0f;
        Color color = text.color;
        color.a = 0; // Start with invisible text
        text.color = color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / duration); // Gradually increase alpha
            text.color = color;
            yield return null;
        }
    }
}
