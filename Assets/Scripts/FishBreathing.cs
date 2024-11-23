using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FishBreathing : MonoBehaviour
{
    public float maxBreath = 10f;
    public float minBreath = 0f;
    public float breathDecreaseRate = 5f;
    public float breathRestoreRate = 5f;

    private float currentBreath;

    public Slider breathSlider;
    public string lostMenuSceneName = "LostMenu"; // Change kardena scene k name k acc 

    private bool isInWater = false;
    private bool isAlive = true;

    void Start()
    {
        currentBreath = maxBreath;

        if (breathSlider != null)
        {
            breathSlider.maxValue = maxBreath;
            breathSlider.value = currentBreath;
        }
    }

    void Update()
    {
        Debug.Log(currentBreath);
        if (!isAlive) return;

        if (isInWater)
        {
            RestoreBreath();
        }
        else
        {
            DecreaseBreath();
        }

        if (breathSlider != null)
        {
            breathSlider.value = currentBreath;
        }
    }

    private void DecreaseBreath()
    {
        float decreaseFactor = Mathf.Lerp(breathDecreaseRate, 0.5f, currentBreath / maxBreath);
        currentBreath -= decreaseFactor * Time.deltaTime;

        if (currentBreath <= minBreath)
        {
            currentBreath = minBreath;
            Die();
        }
    }

    private void RestoreBreath()
    {
        float restoreFactor = Mathf.Lerp(breathRestoreRate, 0.5f, currentBreath / maxBreath);
        currentBreath += restoreFactor * Time.deltaTime;

        if (currentBreath > maxBreath)
        {
            currentBreath = maxBreath;
        }
    }

    private void Die()
    {
        isAlive = false;
        SceneManager.LoadScene(lostMenuSceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
        }
    }
}
