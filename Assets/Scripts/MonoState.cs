using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoState : MonoBehaviour
{
    public InputControl Control;
    public Transform followCam;

    public void Awake(){
        followCam = GameObject.FindObjectOfType<CameraFollow>().transform;
        Control = GetComponent<InputControl>();
    } 

}
