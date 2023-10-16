using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class Simulasi1 : MonoBehaviour
{
    [SerializeField] GameObject finishedContent;
    [SerializeField] GameObject mainMenuButton;

    [SerializeField] Button startKuisButton;

    [SerializeField] GameObject tutorKanvas;
    [SerializeField] GameObject quisKanvas;
    [SerializeField] GameObject titlePanel;
    [SerializeField] GameObject question1Panel;
    [SerializeField] GameObject transisi1Panel;
    [SerializeField] GameObject question2Panel;
    [SerializeField] GameObject transisi2Panel;
    [SerializeField] GameObject endPanel;
    [SerializeField] TMP_Text tutorText;

    public TMP_Text transisi1Text;
    public TMP_Text transisi2Text;
    public TMP_Text endText;
    public TMP_Text scoreText;

    private bool no1QuisIsDone = false;

    public int scorePoint = 0;

    private OLSObject olsObject;
    private OPMObject opmObject;
    private List<PatchCordObject> patchCordObjects = new List<PatchCordObject>();
    private List<BarelObject> barelObject = new List<BarelObject>();

    public bool kalibrasi1IsDone = false;
    public bool kalibrasi2IsDone = false;
    public bool kalibrasi3IsDone = false;
    private bool kalibrasiAllIsDone = false;

    public bool connectPatchCordToOPM = false;
    public bool connectPatchCordToOLS = false;
    public bool connectPatchCordToBarel1 = false;
    public bool connectPatchCordToBarel2 = false;
    public bool connectPatchCordToBarel3 = false;
    public bool connectPatchCordToBarel4 = false;
    public bool connectPatchCordToBarel5 = false;
    public bool connectPatchCordToBarel6 = false;

    public bool allPatchCordConnected = false;

    public bool simulasi1IsDone = false;

    public UnityEvent whenKalibrasiDone;

    void Start()
    {
        olsObject = FindAnyObjectByType<OLSObject>();
        opmObject = FindAnyObjectByType<OPMObject>();
        PatchCordObject[] allPatchCordObjects = FindObjectsOfType<PatchCordObject>();
        patchCordObjects.AddRange(allPatchCordObjects);
        BarelObject[] allbarelObjects = FindObjectsOfType<BarelObject>();
        barelObject.AddRange(allbarelObjects);

        startKuisButton.interactable = false;

        quisKanvas.gameObject.SetActive(false);

        mainMenuButton.SetActive(true);

        finishedContent.SetActive(false);
    }
    
    void Update()
    {
        //Logic Simulasi
        if(connectPatchCordToOPM 
            && connectPatchCordToOLS 
            && connectPatchCordToBarel1 
            && connectPatchCordToBarel2 
            && connectPatchCordToBarel3 
            && connectPatchCordToBarel4)
        {
            allPatchCordConnected = true;

            if (olsObject.waveLength == 1310 && opmObject.waveLength == 1310)
            {
                if (olsObject.modulation == 0)
                {
                    opmObject.angkaHasil = -11.72;
                }
                else if (olsObject.modulation == 270)
                {
                    opmObject.angkaHasil = -14.65;
                }
                else if (olsObject.modulation == 1000)
                {
                    opmObject.angkaHasil = -14.85;
                }
            }

            else if (olsObject.waveLength == 1550 && opmObject.waveLength == 1550)
            {
                if(olsObject.modulation == 0)
                {
                    opmObject.angkaHasil = -14.08;
                    kalibrasi1IsDone = true;
                }
                else if (olsObject.modulation == 270)
                {
                    opmObject.angkaHasil = -17.20;
                    if(kalibrasi1IsDone)
                    {
                        kalibrasi2IsDone = true;
                    }
                }
                else if (olsObject.modulation == 1000)
                {
                    opmObject.angkaHasil = -17.13;
                    if (kalibrasi2IsDone)
                    {
                        kalibrasi3IsDone = true;
                    }
                }
            }
        }
        
        if(!connectPatchCordToOPM
            || !connectPatchCordToOLS
            || !connectPatchCordToBarel1
            || !connectPatchCordToBarel2
            || !connectPatchCordToBarel3
            || !connectPatchCordToBarel4)
        {
            allPatchCordConnected = false;
        }

        //Set text tutor
        if (!kalibrasiAllIsDone)
        {
            if(allPatchCordConnected)
            {
                tutorText.text = "Lakukan pengukuran, hidupkan OPM dan OLSnya";
                if (olsObject.olsIsActive && opmObject.opmIsActive)
                {
                    tutorText.text = "Setelah itu atur panjang gelombang OPM dan OLS ke 1550 nm";
                
                    if(olsObject.waveLength == 1550 && opmObject.waveLength == 1550)
                    {
                        tutorText.text = "pengujian 1 : atur OLS nya menjadi 0 Hz";
                        if (kalibrasi1IsDone)
                        {
                            tutorText.text = "pengujian 1 : \natur OLS nya menjadi 0 Hz, Hasilnya di OPM akan menjadi = -14.08 \n\n" +
                                "pengujian 2 : atur OLSnya ke mode 270 Hz";
                        }
                        if (kalibrasi1IsDone && kalibrasi2IsDone)
                        {
                            tutorText.text = "pengujian 1 : \natur OLS nya menjadi 0 Hz, Hasilnya di OPM akan menjadi = -14.08 \n\n" +
                                "pengujian 2 : \natur OLSnya ke mode 270 Hz, Hasilnya di OPM akan menjadi = -17.20 \n\n" +
                                "pengujian 3 : \natur OLSnya ke mode 1000 Hz";
                        }
                        if (kalibrasi1IsDone && kalibrasi2IsDone && kalibrasi3IsDone)
                        {
                            tutorText.text = "pengujian 1 : \natur OLS nya menjadi 0 Hz, Hasilnya di OPM akan menjadi = -14.08 \n\n" +
                                "pengujian 2 : \natur OLSnya ke mode 270 Hz, Hasilnya di OPM akan menjadi = -17.20 \n\n" +
                                "pengujian 3 : \natur OLSnya ke mode 1000 Hz, Hasilnya di OPM akan menjadi = -17.13";
                        }
                        if (kalibrasi1IsDone && kalibrasi2IsDone && kalibrasi3IsDone && kalibrasiAllIsDone)
                        {
                            return;
                        }
                    }
                }
                if (!olsObject.olsIsActive ||  !opmObject.opmIsActive)
                {
                    tutorText.text = "Lakukan pengukuran, hidupkan OPM da OLSnya";
                }
            }
            else if (!allPatchCordConnected)
            {
                tutorText.text = "Hubungkan kabel pathcord ke OLS kemudian hubungkan ke barel, setelah " +
                    "itu hubungkan juga kabel pathcord pada OPM kemudian hubungkan juga ke " +
                    "barelnya, setelah itu hubungkan barel OLS ke barel OPM ke pathcord " +
                    "yang satu lagi";
            }
        }

        else if (kalibrasiAllIsDone)
        {
            Invoke("PreKuis", 4f);
            startKuisButton.interactable = true;
        }

        //Set text kuis
        if(scorePoint == 2)
        {
            endText.text = "Selamat anda berhasil dengan perolehan nilai :";
            scoreText.text = "100 / 100";
        }
        else if(scorePoint == 1)
        {
            endText.text = "Disayangkan anda tidak memperoleh nilai sempurna";
            scoreText.text = "50 / 100";
        }
        else if (scorePoint == 0) 
        {
            endText.text = "Anda gagal dengan perolehan nilai :";
            scoreText.text = "0 / 100";
        
        }

        if (kalibrasi1IsDone
            && kalibrasi2IsDone
            && kalibrasi3IsDone)
        {
            kalibrasiAllIsDone = true;
        }


        if (simulasi1IsDone)
        {
            mainMenuButton.SetActive(false);

            finishedContent.SetActive(true);
        }
    }

    public void PreKuis()
    {
        tutorText.text = "Anda telah menyelesaikan kalibrasi, tekan tulisan ini untuk melanjutkan ke kuis";
    }

    public void SimulasiKalibrasiDone()
    {
        /*foreach (PatchCordObject patchCordObject in patchCordObjects)
        {
            patchCordObject.enabled = false;
        }
        
        foreach (BarelObject barelObject in barelObject)
        {
            barelObject.enabled = false;
        }*/
        Kuis();

        whenKalibrasiDone?.Invoke();
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
        transisi1Text.text = "Jawaban yang Benar : \n \n c. -16.13";
        transisi2Text.text = "Jawaban yang Benar : \n \n a. 1550 nm di OLS dan 1550 nm di OPM";
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

        simulasi1IsDone = true;
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
    
    public void PatchCordBarel1connect()
    {
        connectPatchCordToBarel1 = true;
    }
    
    public void PatchCordBarel1Disconnect()
    {
        connectPatchCordToBarel1 = false;
    }
    
    public void PatchCordBarel2connect()
    {
        connectPatchCordToBarel2 = true;
    }
    
    public void PatchCordBarel2Disconnect()
    {
        connectPatchCordToBarel2 = false;
    }

    public void PatchCordBarel3connect()
    {
        connectPatchCordToBarel3 = true;
    }

    public void PatchCordBarel3Disconnect()
    {
        connectPatchCordToBarel3 = false;
    }

    public void PatchCordBarel4connect()
    {
        connectPatchCordToBarel4 = true;
    }

    public void PatchCordBarel4Disconnect()
    {
        connectPatchCordToBarel4 = false;
    }
}
