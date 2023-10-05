using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialTrigger : MonoBehaviour
{
    public string triggerTag;
    public UnityEvent onTrigger;

    private StartSceneBehaviour startSceneBehaviour;
    void Start()
    {
        startSceneBehaviour = GetComponent<StartSceneBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            onTrigger?.Invoke();

            this.gameObject.SetActive(false);
        }
    }
}
