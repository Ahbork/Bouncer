using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float lerpSpeed = 2;

    private Vector3 offset;


    private void Awake()
    {
        offset = transform.position;
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (target)
        {
            Vector3 endPos = target.position + offset;
            endPos.y = offset.y;
            transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * lerpSpeed);
        }
    }
}
