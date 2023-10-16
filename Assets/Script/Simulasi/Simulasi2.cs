using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Simulasi2 : MonoBehaviour
{
    [SerializeField] TMP_Text tutorText;

    [SerializeField] GameObject tutorKanvas;
    [SerializeField] GameObject quisKanvas;
    [SerializeField] GameObject titlePanel;
    [SerializeField] GameObject question1Panel;
    [SerializeField] GameObject transisi1Panel;
    [SerializeField] GameObject question2Panel;
    [SerializeField] GameObject transisi2Panel;
    [SerializeField] GameObject endPanel;

    [SerializeField] Button startKuisButton;

    public GameObject olsCanvas;
    public GameObject pathCordInputPanel;
    public GameObject pathCordOutputPanel;

    public TMP_Text transisi1Text;
    public TMP_Text transisi2Text;
    public TMP_Text endText;
    public TMP_Text scoreText;

    public int scorePoint = 0;

    public bool connectPatchCordToOPM = false;
    public bool connectPatchCordToOLS = false;
    public bool allPatchCordConnected = false;

    public bool pengukuranPatchCordIsDone = false;
    public bool simulasi2IsDone = false;

    private bool no1QuisIsDone = false;

    private OLSObject olsObject;
    private OPMObject opmObject;

    void Start()
    {
        olsObject = FindAnyObjectByType<OLSObject>();
        opmObject = FindAnyObjectByType<OPMObject>();

        olsCanvas.SetActive(false);
        pathCordInputPanel.SetActive(false);
        pathCordOutputPanel.SetActive(false);
        startKuisButton.interactable = false;

        pathCordInputPanel.SetActive(false);
        pathCordOutputPanel.SetActive(false);
    }
    
    void Update()
    {
        //logic simulasi
        if(connectPatchCordToOPM && connectPatchCordToOLS)
        {
            allPatchCordConnected = true;
            if(olsObject.waveLength == 1310 && opmObject.waveLength == 1310)
            {
                opmObject.angkaHasil = -6.99;
            }
        }
        if(!connectPatchCordToOPM || !connectPatchCordToOLS)
        {
            allPatchCordConnected = false;
        }

        //set tutor text
        if (!pengukuranPatchCordIsDone)
        {
            if (allPatchCordConnected)
            {
                tutorText.text = "Hidupkan power ON pada OPM dan OLS";
                olsCanvas.SetActive (true);
                pathCordInputPanel.SetActive(false);
                pathCordOutputPanel.SetActive(false);
                if (opmObject.opmIsActive && olsObject.olsIsActive)
                {
                    olsCanvas.SetActive(false);
                    tutorText.text = "Lakukan setting pada OLS yaitu panjang gelombang 1310 nm dan lakukan setting pada OPM yaitu panjang gelombang 1310 nm";
                    if(olsObject.waveLength != 1310 || opmObject.waveLength != 1310)
                    {
                        tutorText.text = "Lakukan setting pada OLS yaitu panjang gelombang 1310 nm dan lakukan setting pada OPM yaitu panjang gelombang 1310 nm";
                    }
                    if(olsObject.waveLength == 1310 && opmObject.waveLength == 1310)
                    {
                        tutorText.text = "Amati hasil display pada OPM";
                        pengukuranPatchCordIsDone = true;
                    }
                }

                if(!opmObject.opmIsActive || !olsObject.olsIsActive)
                {
                    olsCanvas.SetActive(true);
                    tutorText.text = "Hidupkan power ON pada OPM dan OLS";
                }
            }
            if(!allPatchCordConnected)
            {
                pathCordInputPanel.SetActive(true);
                pathCordOutputPanel.SetActive(true);
                olsCanvas.SetActive(false);
                tutorText.text = "Pasang pathcord yang akan diukur pada OPM dan OLS, pastikan konektor terpasang pada adapter dengan tepat, jangan sampai longgar";
            }
        }

        else if (pengukuranPatchCordIsDone)
        {
            startKuisButton.interactable = true;
            Invoke("PreKuis", 2f);
        }

        //Set text kuis
        if (scorePoint == 2)
        {
            endText.text = "Selamat anda berhasil dengan perolehan nilai :";
            scoreText.text = "100 / 100";
        }
        else if (scorePoint == 1)
        {
            endText.text = "Disayangkan anda tidak memperoleh nilai sempurna";
            scoreText.text = "50 / 100";
        }
        else if (scorePoint == 0)
        {
            endText.text = "Anda gagal dengan perolehan nilai :";
            scoreText.text = "0 / 100";

        }
    }

    public void PreKuis()
    {
        tutorText.text = "Amati hasil display pada OPM \n Jika hasil menunjukan -6.99, maka pengukuran selesai, tekan tulisan ini untuk melanjutkan ke Kuis";
    }
    public void Kuis()
    {
        tutorKanvas.SetActive(false);
        quisKanvas.gameObject.SetActive(true);
        StartCoroutine(CloseTitlePanel(5f));
    }

    public void CorrectAnswer()
    {
        scorePoint += 1;

        transisi1Text.text = "Jawaban Benar!";
        transisi2Text.text = "Jawaban Benar!";
    }

    public void WrongAnswer()
    {
        transisi1Text.text = "Jawaban yang Benar : \n \n a. 2,99 dB";
        transisi2Text.text = "Jawaban yang Benar : \n \n d.Konektor Adapater kearah OLS";
    }

    IEnumerator CloseTitlePanel(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        titlePanel.SetActive(false);
        if (!no1QuisIsDone)
        {
            question1Panel.gameObject.SetActive(true);
        }
        else if (no1QuisIsDone)
        {
            question1Panel.gameObject.SetActive(false);
        }
    }

    public void Question1Done()
    {
        no1QuisIsDone = true;
        StartCoroutine(CloseTransisi1Panel(5f));
    }

    IEnumerator CloseTransisi1Panel(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        transisi1Panel.SetActive(false);
        question2Panel.SetActive(true);
    }

    public void Question2Done()
    {
        StartCoroutine(CloseTransisi2Panel(5f));
    }

    IEnumerator CloseTransisi2Panel(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        transisi2Panel.SetActive(false);
        endPanel.SetActive(true);

        simulasi2IsDone = true;
    }

    public void PatchCordOLSConnect()
    {
        connectPatchCordToOLS = true;
    }

    public void PatchCordOLSDisconnect()
    {
        connectPatchCordToOLS = false;
    }

    public void PatchCordOPMConnect()
    {
        connectPatchCordToOPM = true;
    }

    public void PatchCordOPMDisconnect()
    {
        connectPatchCordToOPM = false;
    }
}
