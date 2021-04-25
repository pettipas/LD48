using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoState
{
    public float fallSpeed = 1;
    public float horizontalSpeed = 1;

    public CameraFollow follow;

    public Death death;

    public void OnEnable(){
        death = GetComponent<Death>();
        follow = GameObject.FindObjectOfType<CameraFollow>();
        follow.enabled = false;
    }

    float counter;
    public void LateUpdate() {
        counter+=Time.deltaTime;
        Vector3 n = Control.LatestDirection;
        Vector3 fallStep = new Vector3(0, -1, 0) * Time.deltaTime * fallSpeed;
        Control.Mover.Move(fallStep);

        if(counter > 3.0f && Input.anyKeyDown){
            death.GotoState();
        }
    }
}
