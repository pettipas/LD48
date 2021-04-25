using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFall : MonoState
{
    public float fallSpeed;
    public MonoState Sink;
    public Transform water;
    public Animator cameraAnimator;
    public AudioReverbZone zone;
    public AudioSource spash;
    public AudioSource breeze;
    new void Awake(){
        base.Awake();
        Sink = GetComponent<Sinking>();
    }

    public void LateUpdate(){
        Vector3 n = Control.LatestDirection;
        Vector3 fallStep = new Vector3(0, -1, 0) * Time.deltaTime * fallSpeed;
        
        Control.Mover.Move(fallStep);
        followCam.position += fallStep;
        
        if(transform.position.y < water.transform.position.y){
            cameraAnimator.SafePlay("start_sinking",0,0);
            zone.enabled = true;
            spash.Play();
            breeze.Stop();
            Sink.GotoState();
        }
    }
}
