using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSupport : MonoBehaviour
{
    public void ServerLevelPlay()
    {
        MenuHandler.menuInstance.ServerLevel();
    }

    public void KabelLevelPlay()
    {
        MenuHandler.menuInstance.KabelLevel();
    }

    public void Topik1LevelPlay()
    {
        MenuHandler.menuInstance.Topik1Level();
    }
    
    public void Topik2LevelPlay()
    {
        MenuHandler.menuInstance.Topik2Level();
    }
    
    public void Topik3LevelPlay()
    {
        MenuHandler.menuInstance.Topik3Level();
    }

    public void MainMenuButtonPressed()
    {
        MenuHandler.menuInstance.MainMenuButton();
    }

    public void QuitButtonPressed()
    {
        MenuHandler.menuInstance.QuitButton();
    }
}
