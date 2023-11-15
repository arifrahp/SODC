using System;
using UnityEngine;
using UnityEngine.Events;

public class NotifTrigger : MonoBehaviour
{
    [SerializeField] string tagFilter;
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter))
            return;
        onTriggerEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter))
            return;
        onTriggerExit.Invoke();
    }
}
