using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinking : MonoState
{
    public float fallSpeed = 1;
    public float horizontalSpeed = 1;
    public MonoState Dashing;
    public OctoStart octoStart;
    public OctoPeeks octoPeeks;
    public LayerMask DeathMask;
    public Collider[] deaths = new Collider[1];
    public Death death;
    public Animator fish;
    float speedMult = 1;
    public Vector3 deathExtents;
    new void Awake(){
        base.Awake();
        Dashing = GetComponent<Dashing>();
        death = this.GetComponent<Death>();
    }
    public void OnEnable() {
        deathExtents = Vector3.one/2.5f;
        fish.SafePlay("sinking",0,0);
        octoStart = GameObject.FindObjectOfType<OctoStart>();
        octoPeeks = GameObject.FindObjectOfType<OctoPeeks>();
    }
    public void LateUpdate(){

        if (Physics.OverlapBoxNonAlloc(transform.position, deathExtents, deaths, Quaternion.identity, DeathMask) > 0) {
            if(deaths[0] != null){
                death.GotoState();
                return;
            }
        }


        if(transform.position.y < octoStart.triggerHeight.position.y){
            octoStart.enabled = true;
        }

        if(transform.position.y < octoPeeks.triggerHeight.position.y){
            octoPeeks.enabled = true;
        }

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
