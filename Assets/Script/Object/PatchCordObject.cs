using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PatchCordObject : MonoBehaviour
{
    public UnityEvent onHoldGrab;
    public UnityEvent onHoldRelease;

    public Rigidbody rb;
    public RigidbodyConstraints originalConstraints;

    private Grabbable grabbable;

    void Start()
    {
        grabbable = GetComponent<Grabbable>();
        rb = GetComponent<Rigidbody>();
        originalConstraints = RigidbodyConstraints.FreezeAll;
    }

    private void Update()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            rb.constraints = originalConstraints;
        }
        else
        {
            return;
        }
    }

    public void OnObjectGrab()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
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
}
