using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Complete : MonoBehaviour
{
    [SerializeField] public string sceneToLoad;
    [SerializeField] public string sceneToLoadFry;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Complete")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        if (collision.collider.name == "FryComplete")
        {
            SceneManager.LoadScene(sceneToLoadFry);
        }
    }


}
