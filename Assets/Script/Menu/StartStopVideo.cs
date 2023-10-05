using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartStopVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public void StartButtonPressed()
    {
        videoPlayer.Play();
    }
    
    public void PauseButtonPressed()
    {
        videoPlayer.Pause();
    }
    
    public void SkipButtonPressed()
    {
        videoPlayer.Stop();
    }
}
