using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topik2Behaviour : MonoBehaviour
{
    [SerializeField] GameObject objectOPM;
    [SerializeField] GameObject objectOLS;
    [SerializeField] GameObject opmContent;
    [SerializeField] GameObject olsContent;

    public bool objectIsShow = false;

    private void Start()
    {
        mainMenuButton.SetActive(true);
        finishedContent.SetActive(false);

        LeanTween.scale(objectOPM.gameObject, new Vector3(0f, 0f, 0f), 0f);
        LeanTween.scale(objectOLS.gameObject, new Vector3(0f, 0f, 0f), 0f);

        LeanTween.scale(opmContent.gameObject, new Vector3(0f, 0f, 0f), 0f);
        LeanTween.scale(olsContent.gameObject, new Vector3(0f, 0f, 0f), 0f);

        if (!objectIsShow)
        {
            StartCoroutine(ShowObject(5f));
        }
    }
    public void SpawnObjectZone()
    {
        if (!objectIsShow)
        {
            LeanTween.scale(objectOPM.gameObject, new Vector3(1f, 1, 1), 0.5f);
            LeanTween.scale(objectOLS.gameObject, new Vector3(1f, 1, 1), 0.5f);
            objectIsShow = true;
        }
    }

    IEnumerator ShowObject(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        LeanTween.scale(objectOPM.gameObject, new Vector3(1f, 1, 1), 0.5f);
        LeanTween.scale(objectOLS.gameObject, new Vector3(1f, 1, 1), 0.5f);

        objectIsShow = true;
    }

    public bool opmContentIsShow = false;
    public bool olsContentIsShow = false;

    public void ShowOPMContent()
    {
        LeanTween.scale(opmContent.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
        opmIsDone = true;
    }
    
    public void CloseOPMContent()
    {
        LeanTween.scale(opmContent.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
    }
    
    public void ShowOLSContent()
    {
        LeanTween.scale(olsContent.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
        olsIsDone = true;
    }
    
    public void CloseOLSContent()
    {
        LeanTween.scale(olsContent.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
    }

    public bool opmIsDone = false;
    public bool olsIsDone = false;

    [SerializeField] GameObject mainMenuButton;
    [SerializeField] GameObject finishedContent;

    private void Update()
    {
        if(opmIsDone && olsIsDone)
        {
            MenuHandler.menuInstance.topik2Done = true;
        }

        if (MenuHandler.menuInstance.topik2Done)
        {
            mainMenuButton.SetActive(false);

            finishedContent.SetActive(true);
        }
    }
}
