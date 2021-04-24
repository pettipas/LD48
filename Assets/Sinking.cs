using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinking : MonoState
{
    public float fallSpeed = 1;
    public float horizontalSpeed = 1;
    public MonoState Dashing;

    new void Awake(){
        base.Awake();
        Dashing = GetComponent<Dashing>();
    }

    public void LateUpdate(){
        Vector3 n = Control.LatestDirection;
        Vector3 fallStep = new Vector3(0, -1, 0) * Time.deltaTime * fallSpeed;
        Vector3 moveStep = new Vector3(n.x, 0, 0) * Time.deltaTime * horizontalSpeed;
        Control.Mover.Move(moveStep + fallStep);
        followCam.position += fallStep;
        if(Control.DashPressed){
            Dashing.GotoState();
        }
    }
}
