using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public static MenuHandler menuInstance;

    public bool countDownIsDone = false;
    public bool topik1Done = false;
    public bool topik2Done = false;

    private void Awake()
    {
        if (menuInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            menuInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ServerLevel()
    {
        SceneManager.LoadScene("ServerScene");
    }
    
    public void KabelLevel()
    {
        SceneManager.LoadScene("KabelScene");
    }
    
    public void Topik1Level()
    {
        SceneManager.LoadScene("Topik1");
    }
    
    public void Topik2Level()
    {
        SceneManager.LoadScene("Topik2");
    }
    
    public void Topik3Level()
    {
        SceneManager.LoadScene("Topik3");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
