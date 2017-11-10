using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLocalAsWorld : MonoBehaviour
{
    public Transform follow;

    void LateUpdate()
    {
        transform.rotation = follow.localRotation;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(follow.position, follow.localRotation.eulerAngles * 50.0f);
    }
}
