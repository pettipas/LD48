using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinking : MonoState
{
    public float fallSpeed = 1;
    public float horizontalSpeed = 1;
    public MonoState Dashing;

    float speedMult = 1;
    new void Awake(){
        base.Awake();
        Dashing = GetComponent<Dashing>();
    }

    public void LateUpdate(){
        Vector3 n = Control.LatestDirection;
        
        if(Control.DownPressed) {
            speedMult = 2.0f;
        } else {
            speedMult = 1.0f;
        }

        Vector3 fallStep = new Vector3(0, -1, 0) * Time.deltaTime * fallSpeed * speedMult;
        Vector3 moveStep = new Vector3(n.x, 0, 0) * Time.deltaTime * horizontalSpeed;
        Control.Mover.Move(moveStep + fallStep);
        followCam.position += fallStep;
        if(Control.DashPressed){
            Dashing.GotoState();
        }
    }
}
