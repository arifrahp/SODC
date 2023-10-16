using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioInstance;
    static AudioSource bgmInstance;
    [SerializeField] AudioSource bgm;

    public bool IsMute { get => bgm.mute; }
    public float BgmVolume { get => bgm.volume; }

    private void Start()
    {
        if (bgmInstance != null)
        {
            Destroy(bgm.gameObject);
            bgm = bgmInstance;
        }
        else
        {
            bgmInstance = bgm;
            bgm.transform.SetParent(null);
            DontDestroyOnLoad(bgm.gameObject);
        }
    }

    private void Update()
    {
        if (MenuHandler.menuInstance.videoDonePlay)
        {
            PlayBGM();
        }
    }

    public void PlayBGM(AudioClip clip, bool loop) 
    {
        if (bgm.isPlaying)
        {
            bgm.Stop();
        }

        bgm.clip = clip;
        bgm.loop = loop;
        bgm.Play();
    }

    public void SetMute(bool value)
    {
        bgm.mute = value;
    }

    public void SetBGMVolume(float value)
    {
        bgm.volume = value;
    }

    public void PauseBGM()
    {
        bgm.Play();
    }
    
    public void PlayBGM()
    {
        bgm.Pause();
    }
}
