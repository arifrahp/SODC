using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerObject : MonoBehaviour
{
    [SerializeField] GameObject lamp;
    [SerializeField] Material red;
    [SerializeField] Material green;
    private Rigidbody rb;
    private RigidbodyConstraints originalConstraints;

    private Grabbable grabbable;
    private ServerShelf serverShelf;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabbable = GetComponent<Grabbable>();
        serverShelf = FindAnyObjectByType<ServerShelf>();
        originalConstraints = rb.constraints;
    }

    public void OnObjectPlace()
    {
        /*LeanTween.color(this.gameObject, green.color, 0.5f);
        Debug.Log("Masuk");*/
    }

    public void OnObjectRemove()
    {
        /*LeanTween.color(this.gameObject, green.color, 0.5f);
        Debug.Log("Keluar");*/
    }

    public void OnObjectGrab()
    {
        if (!serverShelf.isDone)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    public void OnObjectRelease()
    {
        if(!grabbable.IsHeld())
        {
            rb.constraints = originalConstraints;
        }
    }   
}
