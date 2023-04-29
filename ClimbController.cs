using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbController : MonoBehaviour
{
    public GameObject xrRig;

    void Start()
    {
        if (xrRig == null)
        {
            xrRig = GameObject.Find("XR Origin");
        }
    }

    public void Grab()
    {

    }

    public void Pull(Vector3 distance)
    {
        xrRig.transform.Translate(distance);
    }

    public void Release()
    {

    }
}
