using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartSceneBehaviour : MonoBehaviour
{
    [SerializeField] GameObject videoCanvas;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject servicePanel;
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] GameObject headCanvas;
    [SerializeField] GameObject videoPlayer;

    [SerializeField] GameObject topik2Locker;
    [SerializeField] GameObject topik3Locker;
    
    [SerializeField] Button topik2Button;
    [SerializeField] Button topik3Button;

    void Start()
    {
        startPanel.SetActive(true);
        headCanvas.SetActive(true);
        videoCanvas.SetActive(false);
        if (!MenuHandler.menuInstance.countDownIsDone)
        {
            MenuHandler.menuInstance.countDownIsDone = true;
            LeanTween.scale(startPanel.gameObject, new Vector3(0f, 0f, 0f), 0f);
            StartCoroutine(CloseFirstPanel(5f));   
        }
        else if (MenuHandler.menuInstance.countDownIsDone) 
        {
            videoPlayer.SetActive(false);
            videoCanvas.SetActive(false);
            headCanvas.SetActive(false);
            LeanTween.scale(startPanel.gameObject, new Vector3(1f, 1f, 1f), 0f);
        }

        servicePanel.SetActive(true);
        tutorialPanel.SetActive(true);
        viewTutorialImage.SetActive(true);
        kursorTutorialImage.SetActive(true);
        finishTutorialImage.SetActive(true);
        toggleView.gameObject.SetActive(true);
        toggleKursor.gameObject.SetActive(true);

        LeanTween.scale(servicePanel.gameObject, new Vector3(0f, 0f, 0f), 0f);
        LeanTween.scale(tutorialPanel.gameObject, new Vector3(0f, 0f, 0f), 0f);
        LeanTween.scale(viewTutorialImage.gameObject, new Vector3(0f, 0f, 0f), 0f);
        LeanTween.scale(kursorTutorialImage.gameObject, new Vector3(0f, 0f, 0f), 0f);
        LeanTween.scale(finishTutorialImage.gameObject, new Vector3(0f, 0f, 0f), 0f);

        LeanTween.alpha(toggleView, 0, 0f);
        LeanTween.alpha(toggleKursor, 0, 0f);

        wallViewLeft.SetActive(false);
        wallViewRight.SetActive(false);
        wallTutorCanvas.SetActive(false);
        headCollider.SetActive(false);
        kursor1Collider.SetActive(false);
        kursor2Collider.SetActive(false);

    }

    private void Update()
    {
        if(!MenuHandler.menuInstance.topik1Done)
        {
            topik2Locker.SetActive(true) ;

            topik2Button.interactable = false;
        }
        else if(MenuHandler.menuInstance.topik1Done)
        {
            topik2Locker.SetActive(false) ;

            topik2Button.interactable = true;
        }
        
        if(!MenuHandler.menuInstance.topik2Done)
        {
            topik3Locker.SetActive(true) ;

            topik3Button.interactable = false;
        }
        else if(MenuHandler.menuInstance.topik2Done)
        {
            topik3Locker.SetActive(false) ;

            topik3Button.interactable = true;
        }
    }
    IEnumerator CloseFirstPanel (float seconds)
    {
        yield return new WaitForSeconds (seconds);

        headCanvas.SetActive (false);
        videoCanvas.SetActive (true);
        videoPlayer.SetActive (true);
    }

    //UI animation
    [SerializeField] GameObject viewTutorialImage;
    [SerializeField] GameObject kursorTutorialImage;
    [SerializeField] GameObject finishTutorialImage;

    public void SkipVideoPressed()
    {
        LeanTween.scale(startPanel.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
        videoPlayer.SetActive(false);
        videoCanvas.SetActive(false);
    }

    public void ServiceButtonPressed()
    {
        LeanTween.scale(startPanel.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
        LeanTween.scale(servicePanel.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
    }

    public void CloseServicePressed()
    {
        LeanTween.scale(servicePanel.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
        LeanTween.scale(startPanel.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
    }

    public void NextToKursorTutorial()
    {
        LeanTween.scale(viewTutorialImage.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
        LeanTween.scale(kursorTutorialImage.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
    }
    
    public void NextToEndTutorial()
    {
        LeanTween.scale(kursorTutorialImage.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
        LeanTween.scale(finishTutorialImage.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
    }

    public void FinishTutorialPressed()
    {
        LeanTween.scale(finishTutorialImage.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
        LeanTween.scale(tutorialPanel.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
        LeanTween.scale(startPanel.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
    }

    //Tutorial Oculus
    [SerializeField] GameObject headCollider;
    [SerializeField] GameObject kursor1Collider;
    [SerializeField] GameObject kursor2Collider;
    [SerializeField] GameObject wallViewLeft;
    [SerializeField] GameObject wallViewRight;
    [SerializeField] GameObject wallTutorCanvas;

    [SerializeField] Button nextToKursorButton;
    [SerializeField] Button nextToEndButton;

    [SerializeField] RectTransform toggleView;
    [SerializeField] RectTransform toggleKursor;

    public bool haveLookedLeft = false;
    public bool haveLookedRight = false;

    public void TutorialButtonPressed()
    {
        haveLookedLeft = false;
        haveLookedRight = false;

        LeanTween.scale(startPanel.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
        LeanTween.scale(tutorialPanel.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
        LeanTween.scale(viewTutorialImage.gameObject, new Vector3(1f, 1f, 1f), 0.5f);

        wallViewLeft.SetActive(true);
        wallViewRight.SetActive(true);
        wallTutorCanvas.SetActive(true);

        headCollider.SetActive(true);
        kursor1Collider.SetActive(true);
        kursor2Collider.SetActive(true);

        LeanTween.alpha(toggleView, 0, 0f);
        LeanTween.alpha(toggleKursor, 0, 0f);

        nextToKursorButton.interactable = false;
        nextToEndButton.interactable = false;

        viewTutorialImage.gameObject.SetActive(true);
    }

    public void LookLeft()
    {
        haveLookedLeft = true;
        if(haveLookedLeft && haveLookedRight)
        {
            LeanTween.alpha(toggleView, 1, 0.5f);
            nextToKursorButton.interactable = true;
            headCollider.SetActive(false);
        }
    }
    
    public void LookRight()
    {
        haveLookedRight = true;
        if(haveLookedLeft && haveLookedRight)
        {
            LeanTween.alpha(toggleView, 1, 0.5f);
            nextToKursorButton.interactable = true;
            headCollider.SetActive(false);
        }
    }

    public void KursorTouch()
    {
        LeanTween.alpha(toggleKursor, 1, 0.5f);
        nextToEndButton.interactable = true;
        kursor1Collider.SetActive(false);
        kursor2Collider.SetActive(false);
    }
}        
