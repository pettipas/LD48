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
    public float fallSpeed;
    public Animator fish;
    public AudioSource eatSound;
    public LayerMask FishMask;
    public Collider[] fishes = new Collider[1];
    public LayerMask DeathMask;
    public Collider[] deaths = new Collider[1];
    public Vector3 extents;
    public Vector3 deathExtents;
    public Death death;
    public AudioSource eaten;

    new void Awake(){
        base.Awake();
        Sink = GetComponent<Sinking>();
        death = this.GetComponent<Death>();
    }

    public void OnEnable(){
        extents = Vector3.one;
        deathExtents = Vector3.one/2.5f;
        Direction = Control.body.transform.forward;
        start = transform.position;
        end = start + Direction * distance;
        progress = 0;
        distanceConsumed = 0;
        fish.SafePlay("attack", 0, 0);
        eatSound.Play();
    }

    // Update is called once per frame
    void LateUpdate()
    {
         if (Physics.OverlapBoxNonAlloc(transform.position, deathExtents, deaths, Quaternion.identity, DeathMask) > 0) {
            if(deaths[0] != null){
                death.GotoState();
            }
        }

         if (Physics.OverlapBoxNonAlloc(transform.position, extents, fishes, Quaternion.identity, FishMask) > 0) {
            Fish f = fishes[0].GetComponent<Fish>();
            Destroy(f.gameObject);
            eaten.Play();
        }

        Control.Mover.Move(Direction * speed * Time.smoothDeltaTime);
        distanceConsumed += speed * Time.smoothDeltaTime;
        progress = distanceConsumed / distance;
        if(progress >= 1 && fish.AtEndOfAnimation()){
            Sink.GotoState();
        }
    }

    public void OnDrawGizmos() {
        Gizmos.DrawSphere(start, 0.3f);
        Gizmos.DrawSphere(end, 0.3f);
    }
}
