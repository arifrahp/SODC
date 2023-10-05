using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerMeterObject : MonoBehaviour
{
    public UnityEvent onHoldGrab;
    public UnityEvent onHoldRelease;

    private Rigidbody rb;
    private RigidbodyConstraints originalConstraints;

    private Grabbable grabbable;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabbable = GetComponent<Grabbable>();
        originalConstraints = rb.constraints;
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
}
