using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 velocity;

    public Vector3 TargetPosition {
        get{
            return new Vector3(this.transform.position.x,target.position.y, this.transform.position.z);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = TargetPosition;
    }
}
