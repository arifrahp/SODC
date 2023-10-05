using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    public UnityEvent onPressed; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IndexTrigger"))
        {
            onPressed?.Invoke();
        }
    }
}
