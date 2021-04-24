using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoState
{
    public Vector3 Direction;
    public float speed;
    public float distance;
    public MonoState Sink;
    public AnimationCurve accleration;
    public Vector3 start;
    public Vector3 end;
    public float progress = 0;

    public float distanceConsumed;

    new void Awake(){
        base.Awake();
        Sink = GetComponent<Sinking>();
    }

    public void OnEnable(){
        Direction = Control.body.transform.forward;
        start = transform.position;
        end = start + Direction * distance;
        progress = 0;
        distanceConsumed = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Control.Mover.Move(Direction * speed * Time.smoothDeltaTime);
        distanceConsumed += speed * Time.smoothDeltaTime;
        progress = distanceConsumed / distance;
        if(progress >= 1){
            Sink.GotoState();
        }
    }

    public void OnDrawGizmos() {
        Gizmos.DrawSphere(start, 0.3f);
        Gizmos.DrawSphere(end, 0.3f);
    }
}
