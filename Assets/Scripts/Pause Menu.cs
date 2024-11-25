using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas canvas;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            }else{
                Pause();
            }
        }   
    }
    public void Pause(){
        canvas.enabled = true;
        Time.timeScale = 0;
        isPaused = true;
    }
    public void Resume(){
        canvas.enabled = false;
        Time.timeScale = 1;
        isPaused = false;
    }
}
