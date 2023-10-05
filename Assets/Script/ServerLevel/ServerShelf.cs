using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ServerShelf : MonoBehaviour
{
    [SerializeField] int allServerCount;
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject infoButton;
    public int serverCount = 0;
    public bool isDone = false;

    private void Awake()
    {
        finishPanel.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        AllServerPlace();
        if (isDone == true)
        {
            GameWinning();
        }
    }

    public void OnServerPlace()
    {
        serverCount += 1;
    }

    public void OnServerRemove()
    {
        serverCount -= 1;
    }

    private void AllServerPlace()
    {
        if(serverCount == allServerCount)
        {
            isDone = true;
        }
    }

    private void GameWinning()
    {
        finishPanel.gameObject.SetActive(true);
        infoButton.gameObject.SetActive(false);
    }

}
