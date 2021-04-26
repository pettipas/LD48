using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Transform body;
    public CharacterController controller;

    public float speed;
    public Vector3 direction;
    public void Start(){
        speed = Random.Range(0.5f,2.5f);
        StartCoroutine(FlipAround());
    }

    void Update()
    {
        controller.Move(direction * Time.deltaTime * speed);
         if ((controller.collisionFlags & CollisionFlags.Sides) != 0)
        {
            if(direction == Vector3.right){
                body.forward = Vector3.left; 
                direction = body.forward;
            }else{
                body.forward = Vector3.right; 
                direction = body.forward;
            }
        }
    }

    public IEnumerator FlipAround() {

        if(Random.value > 0.5){
            body.forward = Vector3.left;
            direction = body.forward;
            controller.Move(direction * Time.deltaTime * speed);
            if ((controller.collisionFlags & CollisionFlags.Sides) != 0)
            {
                body.forward = Vector3.right; 
                direction = body.forward;
            }
        }else {
            body.forward = Vector3.right; 
            direction = body.forward;
            controller.Move(direction * Time.deltaTime * speed);
            if ((controller.collisionFlags & CollisionFlags.Sides) != 0)
            {
                body.forward = Vector3.left; 
                direction = body.forward;
            }
        }

        speed = Random.Range(0.5f,2.5f);
        yield return new WaitForSeconds(Random.Range(3,6));
        yield return  StartCoroutine(FlipAround());
    }
}
