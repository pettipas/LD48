using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoStart : MonoBehaviour
{
    
    public Transform triggerHeight;

    public Animator octoAni;
    Vector3 Direction;
    float speed;

    float slow;

    float countdown;

    public AudioSource sound;

    public void OnEnable() {
        sound.Play();
        octoAni.enabled = true;
        if(Random.value > 0.5f){
            Direction = Vector3.right;
        }else {
            Direction = Vector3.left;
        }
        speed = Random.Range(1,3);
    }

    void Update()
    {   
        if(countdown < 20){
            countdown += Time.deltaTime;
        }
        
        if(countdown < 2){

            return;
        }
        transform.position += Direction * speed * Time.smoothDeltaTime;

        if(countdown > 5){
            speed = 0.5f;
        }
    }
}
