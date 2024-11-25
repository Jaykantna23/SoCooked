using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Complete : MonoBehaviour
{
    [SerializeField] public string sceneToLoad;
    [SerializeField] public string sceneToLoadFry;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.GetComponent<Collider>().gameObject.CompareTag("Player"))
            SceneManager.LoadScene(sceneToLoad);
        
    
    }


}
