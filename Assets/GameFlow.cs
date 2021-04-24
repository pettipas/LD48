using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{

    public CameraFollow cameraFollow;
    public Transform player;

    public void Awake(){
        cameraFollow = GameObject.FindObjectOfType<CameraFollow>();
        player = GameObject.FindObjectOfType<InputControl>().transform;
    }

    float distance;
    float distanceTraveled;
    public void Start(){
    }


 
}
