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
    public List<PlacePoint> placePoints = new List<PlacePoint>();

    public bool isHold = false;

    public bool isChildOfPlacePoint = false;

    private Grabbable grabbable;

    void Start()
    {
        grabbable = GetComponent<Grabbable>();
        rb = GetComponent<Rigidbody>();
        originalConstraints = RigidbodyConstraints.FreezeAll;

        PlacePoint[] foundPlacePoints = FindObjectsOfType<PlacePoint>();
        placePoints.AddRange(foundPlacePoints);
    }

    private void Update()
    {
        CheckIfChildOfPlacePoint();
        if (!isChildOfPlacePoint)
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody>();
            }
            if (rb.constraints == RigidbodyConstraints.None && !isHold)
            {
                rb = GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        /*if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            rb.constraints = originalConstraints;
        }*/
    }

    public void OnObjectGrab()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.constraints = RigidbodyConstraints.None;
        onHoldGrab?.Invoke();
        isHold = true;
    }

    public void OnObjectRelease()
    {
        if (!grabbable.IsHeld())
        {
            rb.constraints = originalConstraints;
            onHoldRelease?.Invoke();
        }
        isHold = false;
    }

    void CheckIfChildOfPlacePoint()
    {
        Transform parent = transform.parent;
        while (parent != null)
        {
            if (parent.GetComponent<PlacePoint>() != null)
            {
                isChildOfPlacePoint = true;
                break;
            }
            parent = parent.parent;
        }
        if (!isChildOfPlacePoint)
        {
            isChildOfPlacePoint = false;
        }
    }
    public bool IsChildOfPlacePoint()
    {
        return isChildOfPlacePoint;
    }
}
