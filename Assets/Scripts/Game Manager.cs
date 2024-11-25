using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject text;
    public GameObject panel;
    // public void Start(){
    //     panel.SetActive(false);
    // }
    public void StartButton()
    {
        SceneManager.LoadScene("MainLevel");
        PlayerPrefs.SetString("savepoint", "MainLevel");
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
        Time.timeScale = 1;
        if (PlayerPrefs.HasKey("savepoint"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("savepoint"));
        }
        else
        {
            SceneManager.LoadScene("MainLevel");
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
