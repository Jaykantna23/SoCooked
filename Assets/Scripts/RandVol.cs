using UnityEngine;
using UnityEngine.UI;

public class RandVol : MonoBehaviour
{
    public Slider volumeSlider;          // Assign the slider in the inspector
    public Text guessText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Guess()
    {
        float guess = Random.Range(1, 100);
        volumeSlider.value = guess;
        guessText.text = guess.ToString();
    }
}