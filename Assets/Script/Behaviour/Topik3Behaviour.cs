using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Topik3Behaviour : MonoBehaviour
{
    [SerializeField] ParticleSystem particleEffect;

    public GameObject simulasi1;
    public GameObject lockerSimulasi1;
    public Button simulasi1Button;
    public GameObject simulasi2;
    public Button simulasi2Button;
    public GameObject lockerSimulasi2;

    public GameObject transitionSphere;

    private GameObject simulasiCurentlyInActive;

    
    void Start()
    {
        simulasi1.SetActive(false); 
        lockerSimulasi1.SetActive(false);
        simulasi2.SetActive(false);
        lockerSimulasi2.SetActive(false);

        transitionSphere.SetActive(true);
        LeanTween.scale(transitionSphere.gameObject, new Vector3(0f, 0f, 0f), 0f);
        LeanTween.alpha(transitionSphere.gameObject, 1, 0f);

        simulasi1Button.interactable = true;
        simulasi2Button.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(simulasiCurentlyInActive == simulasi1)
        {
            simulasi2Button.interactable = true;
            lockerSimulasi2.SetActive(false);

            simulasi1Button.interactable = false;
            lockerSimulasi1.SetActive(true);
        }
        
        if(simulasiCurentlyInActive == simulasi2)
        {
            simulasi1Button.interactable = true;
            lockerSimulasi1.SetActive(false);

            simulasi2Button.interactable = false;
            lockerSimulasi2.SetActive(true);
        }
    }

    public void SimulasiPengukuranRedaman()
    {
        if(simulasiCurentlyInActive == null)
        {
            simulasiCurentlyInActive = simulasi1;
            simulasiCurentlyInActive.SetActive(true);

            TransitionEffect();
        }

        if(simulasiCurentlyInActive != null && simulasiCurentlyInActive != simulasi1)
        {
            simulasiCurentlyInActive.SetActive(false);
            simulasiCurentlyInActive = simulasi1;
            simulasiCurentlyInActive.SetActive(true);

            TransitionEffect();
        }
    }
    
    public void SimulasiPengukuranPatchcord()
    {
        if (simulasiCurentlyInActive == null)
        {
            simulasiCurentlyInActive = simulasi2;
            simulasiCurentlyInActive.SetActive(true);

            TransitionEffect();
        }

        if (simulasiCurentlyInActive != null && simulasiCurentlyInActive != simulasi2)
        {
            simulasiCurentlyInActive.SetActive(false);
            simulasiCurentlyInActive = simulasi2;
            simulasiCurentlyInActive.SetActive(true);

            TransitionEffect();
        }
    }

    public void TransitionEffect()
    {
        particleEffect.Play();
        /*bool sphereIsShow = false;

        if (!sphereIsShow)
        {
            LeanTween.scale(transitionSphere.gameObject, new Vector3(20f, 20f, 20f), 0.2f);
            LeanTween.alpha(transitionSphere.gameObject, 0, 0.2f);
            sphereIsShow = true;
        }

        if (sphereIsShow)
        {
            LeanTween.scale(transitionSphere.gameObject, new Vector3(0f, 0f, 0f), 0f);
            LeanTween.alpha(transitionSphere.gameObject, 1, 0f);
            sphereIsShow = false;
        }*/
    }
}
