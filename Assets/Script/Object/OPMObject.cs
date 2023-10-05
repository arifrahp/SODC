using Autohand;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class OPMObject : MonoBehaviour
{
    [SerializeField] GameObject opmCanvas;
    [SerializeField] GameObject backlightPanel;
    [SerializeField] TMP_Text waveLengthText;
    [SerializeField] TMP_Text angkaHasilText;

    public double angkaHasil = 00.00;
    public int waveLength;
    public int waveLengthStep = 1;

    public Rigidbody rb;
    public RigidbodyConstraints originalConstraints;

    public bool opmIsActive = false;
    public bool backLightIsOn = false;

    private Grabbable grabbable;
    
    public UnityEvent onHoldGrab;
    public UnityEvent onHoldRelease;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabbable = GetComponent<Grabbable>();
        originalConstraints = rb.constraints;

        opmCanvas.gameObject.SetActive(false);
        backlightPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(waveLengthStep == 1)
        {
            waveLength = 850;
        }
        else if (waveLengthStep == 2)
        {
            waveLength = 1000;
        }
        else if (waveLengthStep == 3)
        {
            waveLength = 1310;
        }
        else if (waveLengthStep == 4)
        {
            waveLength = 1490;
        }
        else if (waveLengthStep == 5)
        {
            waveLength = 1550;
        }
        else if (waveLengthStep == 6)
        {
            waveLengthStep = 1;
        }

        waveLengthText.text = waveLength.ToString();
        angkaHasilText.text = angkaHasil.ToString();
    }

    public void OnObjectGrab()
    {
        rb.constraints = RigidbodyConstraints.None;
        onHoldGrab?.Invoke();
    }

    public void OnObjectRelease()
    {
        if (!grabbable.IsHeld())
        {
            rb.constraints = originalConstraints;
            onHoldRelease?.Invoke();
        }
    }

    public void TurnOnOPL()
    {
        opmCanvas.gameObject.SetActive(true);
        opmIsActive = true;
    }

    public void TurnOffOPL()
    {
        opmCanvas.gameObject.SetActive(false);
        opmIsActive = false;
    }

    public void PowerButtonPressed()
    {
        if (!opmIsActive)
        {
            TurnOnOPL();
        }
        else if (opmIsActive)
        {
            TurnOffOPL();
        }
    }

    public void TurnOnBackLight()
    {
        backlightPanel.gameObject.SetActive(true);
        backLightIsOn = true;
        Debug.Log("nyalain");
    }
    
    public void TurnOffBackLight()
    {
        backlightPanel.gameObject.SetActive(false);
        backLightIsOn = false;
        Debug.Log("Matiin");
    }

    public void LightButtonPressed()
    {
        if(opmIsActive)
        {
            if (!backLightIsOn)
            {
                TurnOnBackLight();
            }
            else if(backLightIsOn) 
            {
                TurnOffBackLight();
            }
        }
    }

    public void WaveButtonPressed()
    {
        if (opmIsActive)
        {
           waveLengthStep += 1;
        }
    }
}   
