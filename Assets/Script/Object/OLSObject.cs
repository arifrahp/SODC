using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Events;

public class OLSObject : MonoBehaviour
{
    [SerializeField] GameObject screenOLSCanvas;
    [SerializeField] TMP_Text waveLengthText;
    [SerializeField] TMP_Text modulationText;

    public int modulation;
    public int waveLength;
    public int modulationStep = 1;
    public int waveLengthStep = 1;

    public bool olsIsActive = false;

    public Rigidbody rb;
    public RigidbodyConstraints originalConstraints;

    private Grabbable grabbable;

    public UnityEvent onHoldGrab;
    public UnityEvent onHoldRelease;

    private void Start()
    {
        screenOLSCanvas.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        grabbable = GetComponent<Grabbable>();
        originalConstraints = rb.constraints;
    }

    private void Update()
    {
        if(waveLengthStep == 1)
        {
            waveLength = 850;
        }
        else if(waveLengthStep == 2) 
        {
            waveLength = 1310;
        }
        else if (waveLengthStep == 3)
        {
            waveLength = 1550;
        }
        else if (waveLengthStep == 4)
        {
            waveLengthStep = 1;
        }
        
        if(modulationStep == 1)
        {
            modulation = 0;
        }
        else if(modulationStep == 2)
        {
            modulation = 270;
        }
        else if (modulationStep == 3)
        {
            modulation = 1000;
        }
        else if (modulationStep == 4)
        {
            modulation = 2000;
        }
        else if (modulationStep == 5)
        {
            modulationStep = 1;
        }

        waveLengthText.text = waveLength.ToString();
        modulationText.text = modulation.ToString();
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
        screenOLSCanvas.gameObject.SetActive(true);
        olsIsActive = true;
    }

    public void TurnOffOPL()
    {
        screenOLSCanvas.gameObject.SetActive(false);
        olsIsActive = false;
    }

    public void PowerButtonPressed()
    {
        if (!olsIsActive)
        {
            TurnOnOPL();
        }
        else if (olsIsActive)
        {
            TurnOffOPL();
        }
    }

    public void WaveButtonPressed()
    {
        if (olsIsActive)
        {
            waveLengthStep += 1;
        }
    }
    
    public void ModeButtonPressed()
    {
        if (olsIsActive)
        {
            modulationStep += 1;
        }
    }
}
