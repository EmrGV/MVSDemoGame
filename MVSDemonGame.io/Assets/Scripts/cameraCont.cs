using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCont : MonoBehaviour
{
    public Transform targetobj;
    public float smoothFactor = 0.5f;
    public bool lookAtTarget = false;
    public Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - targetobj.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newpos = targetobj.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newpos, smoothFactor);
        if (lookAtTarget)
        {
            transform.LookAt(targetobj);
        }
    }
}
