using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarelObject : MonoBehaviour
{
    public Rigidbody rb;
    public RigidbodyConstraints originalConstraints;

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
    }

    public void OnObjectRelease()
    {
        if (!grabbable.IsHeld())
        {
            rb.constraints = originalConstraints;
        }
    }
}
