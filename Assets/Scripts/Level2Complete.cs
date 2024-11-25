using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Complete : MonoBehaviour
{
    [SerializeField] public string sceneToLoad;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Complete")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }


}
