using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Vector3 checkpoint,startposition;
    public bool checkedcheckpoint=false;
    public PlayExit playexit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCheckPoint(Vector3 position)
    {   
        checkpoint=position;
        checkedcheckpoint=true;
    }
    public void StartFromCheckPoint()
    {
        if(checkedcheckpoint){
            gameObject.transform.position=checkpoint;
            playexit.Play();
        }

        else StartFromStart();
    }
    public void StartFromStart()
    {
        gameObject.transform.position=startposition;
        playexit.Play();
    }
    public void Exit()
    {
        Application.Quit();
    }
    
}
