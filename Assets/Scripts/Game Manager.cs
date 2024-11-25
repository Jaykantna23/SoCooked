using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject text;
    public GameObject panel;
    public void Start(){
        panel.SetActive(false);
    }
    public void StartButton()
    {
        SceneManager.LoadScene("level1");
        if(!PlayerPrefs.HasKey("savepoint"))
        {
            PlayerPrefs.SetString("savepoint", "level1");
        }
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("savepoint"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("savepoint"));
        }
        else
        {
            text.SetActive(true);
            Invoke("textoff", 1f);
        }
    }

    public void textoff()
    {
        text.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
    public void Restart()
    {
        if (PlayerPrefs.HasKey("savepoint"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("savepoint"));
        }
        else
        {
            SceneManager.LoadScene("level1");
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Instructions(){
        panel.SetActive(true);
    }
    public void CloseInstructions(){
        panel.SetActive(false);
    }
}
