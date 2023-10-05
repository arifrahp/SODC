using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableObject : MonoBehaviour
{
    private Rigidbody rb;
    private RigidbodyConstraints originalConstraints;

    private Grabbable grabbable;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabbable = GetComponent<Grabbable>();
        originalConstraints = rb.constraints;
    }

    public void OnObjectPlace()
    {

    }

    public void OnObjectRemove()
    {

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
